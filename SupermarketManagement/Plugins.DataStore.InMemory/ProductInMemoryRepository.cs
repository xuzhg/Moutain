using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private List<Product> _products;
        public ProductInMemoryRepository()
        {
            _products = new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    CategoryId = 1,
                    Name = "Iced Tea",
                    Quantity = 100,
                    Price = 1.99
                },
                new Product
                {
                    ProductId = 2,
                    CategoryId = 1,
                    Name = "Canada Dry",
                    Quantity = 200,
                    Price = 1.99
                },
                new Product
                {
                    ProductId = 3,
                    CategoryId = 2,
                    Name = "Whole Wheat Bread",
                    Quantity = 300,
                    Price = 1.50
                },
                new Product
                {
                    ProductId = 4,
                    CategoryId = 2,
                    Name = "White Bread",
                    Quantity = 300,
                    Price = 1.50
                },
            };
        }

        public void AddProduct(Product product)
        {
            if (_products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }

            if (_products.Count > 0)
            {
                int maxId = _products.Max(x => x.ProductId);
                product.ProductId = maxId + 1;
            }
            else
            {
                product.ProductId = 1;
            }

            _products.Add(product);
        }

        public void DeleteProduct(int ProductId)
        {
            _products.Remove(GetProductById(ProductId));
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        public Product GetProductById(int ProductId)
        {
            return _products.FirstOrDefault(x => x.ProductId == ProductId);
        }

        public void UpdateProduct(Product Product)
        {
            var ProductToUpdate = _products.FirstOrDefault(x => x.ProductId == Product.ProductId);

            if (ProductToUpdate != null)
            {
                ProductToUpdate.Name = Product.Name;
                ProductToUpdate.CategoryId = Product.CategoryId;
                ProductToUpdate.Quantity = Product.Quantity;
                ProductToUpdate.Price = Product.Price;
            }
        }
    }
}
