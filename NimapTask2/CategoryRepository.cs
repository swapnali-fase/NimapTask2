using NimapTask2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NimapTask2.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryContext _context;

    public CategoryRepository(CategoryContext context)
    {
        _context = context;
    }

    public IEnumerable<Category> GetCategories()
    {
        return _context.Categories.ToList();
    }

    public Category GetCategoryById(int id)
    {
        return _context.Categories.Find(id);
    }

    public void AddCategory(Category category)
    {
        _context.Categories.Add(category);
        Save();
    }

    public void UpdateCategory(Category category)
    {
        _context.Entry(category).State = System.Data.Entity.EntityState.Modified;
        Save();
    }

    public void DeleteCategory(int id)
    {
        var category = _context.Categories.Find(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            Save();
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
}