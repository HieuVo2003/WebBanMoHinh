using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Design;
using WebMoHinh.Models;
using WebMoHinh.Repositories;

namespace WebMoHinh.Controllers
{
    public class CategoriesController : Controller
    {
        
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ProductDbContext _context;

        public CategoriesController(IProductRepository productRepository, ICategoryRepository
        categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> Index()
        {
            var category = await _categoryRepository.GetAllAsync();
            return View(category);
        }
        public async Task<IActionResult> Display(int CategoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(CategoryId);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.AddAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        public async Task<IActionResult> Update(int CategoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(CategoryId);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int CategoryId, Category category)
        {
            if (CategoryId != category.CategoryId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _categoryRepository.UpdateAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        public async Task<IActionResult> Delete(int CategoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(CategoryId);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int CategoryId)
        {
            await _categoryRepository.DeleteAsync(CategoryId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Search(int CategoryId)
        {
            var searchResults = _context.Products.Where(p => p.CategoryId == CategoryId).ToList();
            return View("SearchResult", searchResults);
        }
    }
}
