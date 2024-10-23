using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebMoHinh.Models;
using WebMoHinh.Repositories;
using X.PagedList;

namespace WebMoHinh.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly ProductDbContext _context;
        public HomeController(ProductDbContext context, ILogger<HomeController> logger, IProductRepository productRepository)
        {
            _context = context;
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            page = page < 1 ? 1 : page;
            int pageSize = 8;
            var products = _productRepository.GetAllAsync().Result.ToPagedList(page, pageSize);
            return View(products);
        }
        public IActionResult ShowPaging(int page = 1)
        {
            page = page < 1 ? 1 : page;
            int pageSize = 8;
            var product = _productRepository.GetAllAsync().Result.ToPagedList(page, pageSize);
            return View(product);
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
        public ActionResult Search(string query)
        {
            ViewBag.Query = query;
            var searchResults = _context.Products.Where(p => p.Name.Contains(query) || p.Description.Contains(query)).ToList();
            return View("SearchResult", searchResults);
        }
        public IActionResult SearchResultCate(int categoryId)
        {
            ViewBag.Category = categoryId;
            var searchResults = _context.Products.Where(p => p.CategoryId == categoryId).ToList();
            return View(searchResults);
        }
        [Route("/Identity")]
        public IActionResult RedirectToHomeIndex()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
