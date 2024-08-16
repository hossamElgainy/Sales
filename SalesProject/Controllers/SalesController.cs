using Domain.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.IService;
using System.Security.Claims;
using System;
using SalesProject.VM;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Specification;

namespace SalesProject.Controllers
{
    public class SalesController(IUnitOfWork unitOfWork) : Controller
    {
        private readonly IUnitOfWork _unitOfWork=unitOfWork;
        public async Task<IActionResult> Index()
        {
            var Sales = await _unitOfWork.Repository<Sales>().GetAllWithSpecAsync(new GetSaledProductsSpecification());
            return View(Sales);
        }
        public async Task<ActionResult> Add()
        {
            var products = await _unitOfWork.Repository<Product>().GetAllAsync();

            ViewBag.Products = new SelectList(products, "Id", "Name");
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(AddPurchaseDto dto)
        {

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var product = await _unitOfWork.Repository<Product>().GetBYIdAsync(dto.ProductId);
            if (product == null)
                return View();
            if (product.Quentity < dto.Quentity)
                ModelState.AddModelError("Quentity", "الكميه المتاحه لا تكفي");

            var sale = new Sales
            {
                Id = Guid.NewGuid(),
                ProductId = dto.ProductId,
                Quentity = dto.Quentity,
                PurchasingPrice = product.PurchasingPrice,
                SellingPrice = dto.Price,
                CreatedAt = DateTime.Now,
            };
            if (ModelState.IsValid)
            {
                await _unitOfWork.Repository<Sales>().Add(sale);
                await _unitOfWork.Complete();

                product.Quentity -= dto.Quentity;
                _unitOfWork.Repository<Product>().Update(product);
                await _unitOfWork.Complete();
                return RedirectToAction("Add", "Sales");
            }
            return View(sale);
        }
    }
}
