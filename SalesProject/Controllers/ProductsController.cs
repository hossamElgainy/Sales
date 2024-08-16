using Domain.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.IService;
using SalesProject.Domain.Specification;
using SalesProject.VM;
using System;
using System.Security.Claims;

namespace SalesProject.Controllers
{
    [Authorize]
    public class ProductsController(IUnitOfWork unitOfWork) : Controller
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var Products = await _unitOfWork.Repository<Product>().GetAllWithSpecAsync(new BaseSpecification<Product>(z=>z.UserId==userId));
            return View(Products);
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(AddProductDto dto)
        {

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                PurchasingPrice = dto.Price,
                Quentity = dto.Quentity,
                UserId = userId,                                
            };
            if (ModelState.IsValid)
            {
                await _unitOfWork.Repository<Product>().Add(product);
                await _unitOfWork.Complete();
                return View();
            }
            return View(product);
        }
        public async Task<ActionResult> Edit(Guid Id)
        {
            var product = await _unitOfWork.Repository<Product>().GetBYIdAsync(Id);

            return View(product);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid Id, Product dto)
        {

            var product = await _unitOfWork.Repository<Product>().GetBYIdAsync(Id);

            product.Name = dto.Name;
            product.PurchasingPrice = dto.PurchasingPrice;
            product.Quentity = dto.Quentity;
            product.UserId = dto.UserId;
            
            if (ModelState.IsValid)
            {
                _unitOfWork.Repository<Product>().Update(product);
                await _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}
