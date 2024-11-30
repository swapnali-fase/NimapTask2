using NimapTask2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimapTask2
{
    public interface IProductRepository
    {
        // Method to get all products with their categories
        IEnumerable<Product> GetProducts();

        // Method to get a single product by its ID
        Product GetProductById(int id);

        // Method to add a new product
        void AddProduct(Product product);

        // Method to update an existing product
        void UpdateProduct(Product product);

        // Method to delete a product by its ID
        void DeleteProduct(int id);

        // Method to save changes to the database
        void Save();
    }
}
