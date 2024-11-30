using NimapTask2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NimapTask2.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly CategoryContext _context;

        public ProductRepository(CategoryContext context)
        {
            _context = context;
        }

        // Get all products with their associated categories
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }

        // Get a single product by its ID
        public Product GetProductById(int id)
        {
            return _context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
        }

        // Add a new product
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            Save();
        }

        // Update an existing product
        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            Save();
        }

        // Delete a product by its ID
        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                Save();
            }
        }

        // Save changes to the database
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}