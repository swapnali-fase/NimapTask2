using NimapTask2.Models;
using NimapTask2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NimapTask2.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController()
        {
            _categoryRepo = new CategoryRepository(new CategoryContext());
        }

        public ActionResult Index()
        {
            var categories = _categoryRepo.GetCategories();
            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.AddCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public ActionResult Edit(int id)
        {
            var category = _categoryRepo.GetCategoryById(id);
            if (category == null)
                return HttpNotFound();

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public ActionResult Delete(int id)
        {
            var category = _categoryRepo.GetCategoryById(id);
            if (category == null)
                return HttpNotFound();

            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _categoryRepo.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
