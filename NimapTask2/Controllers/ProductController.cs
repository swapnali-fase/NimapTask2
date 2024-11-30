using NimapTask2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NimapTask2.Controllers
{
    public class ProductController : Controller
    {
        private readonly CategoryContext _context;

        // Constructor to initialize the database context
        public ProductController()
        {
            _context = new CategoryContext();
        }
        public ActionResult Home()
        {
           return View();

        }

        public ActionResult Info()
        {
            
            return View();
        }
        // GET: Product
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            try
            {
                var products = _context.Products
                    .Include("Category") // Use string-based navigation if lambda fails
                    .OrderBy(p => p.ProductId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                int totalProducts = _context.Products.Count();
                ViewBag.TotalPages = (int)Math.Ceiling((double)totalProducts / pageSize);
                ViewBag.CurrentPage = page;

                return View(products);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(new List<Product>()); // Return an empty list if an error occurs
            }

        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CId", "CName");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(_context.Categories, "CId", "CName", product.CategoryId);
            return View(product);
        }



        // GET: Product/Edit/{id}
        public ActionResult Edit(int id)
        {
            // Fetch the product to be edited
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            // Populate ViewBag.Categories with CId and CategoryName
            ViewBag.Categories = _context.Categories
                .Select(c => new { c.CId, c.CName })
                .ToList();

            return View(product);
        }
        // POST: Product/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (!_context.Categories.Any(c => c.CId == product.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "The selected category does not exist.");
                ViewBag.Categories = _context.Categories.ToList();
                return View(product);
            }

            if (ModelState.IsValid)
            {
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(product);
        }

        // GET: Product/Delete/{id}
        public ActionResult Delete(int id)
        {
            var product = _context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Product/Details/{id}
        public ActionResult Details(int id)
        {
            var product = _context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }
    }
}