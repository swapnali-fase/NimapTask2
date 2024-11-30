using NimapTask2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimapTask2.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
        void Save();
    }
}
