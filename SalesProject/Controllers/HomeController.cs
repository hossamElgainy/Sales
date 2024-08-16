using Domain.DomainModels;
using Microsoft.AspNetCore.Mvc;
using SalesProject.Domain.IService;
using SalesProject.Models;
using SalesProject.VM;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;

namespace SalesProject.Controllers
{
    public class HomeController(IUnitOfWork unitOfWork, ILogger<HomeController> logger) : Controller
    {
        private readonly ILogger<HomeController> _logger =logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var productsCount = await _unitOfWork.Repository<Product>().CountAsync(z => z.UserId == userId);
            var totalPurchase = await _unitOfWork.Repository<Sales>().GetAllAsync();
            var revenue = totalPurchase.Sum(z=>z.Quentity*z.SellingPrice);
            var statistics = new StatisticsDto
            {
                Products = productsCount,
                Revenue = revenue - totalPurchase.Sum(z => z.Quentity * z.PurchasingPrice),
            };
            return View(statistics);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
