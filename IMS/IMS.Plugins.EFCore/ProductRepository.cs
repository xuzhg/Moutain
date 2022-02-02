using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMSContext context;

        public ProductRepository(IMSContext context)
        {
            this.context = context;
        }

        public async Task<List<Product>> GetProductsByNameAsync(string name = "")
        {
            return await this.context.Products
                .Where(x => (x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
               string.IsNullOrWhiteSpace(name)) && x.IsActive).ToListAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            if (this.context.Products.Any(
                x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }

            this.context.Products.Add(product);
            await this.context.SaveChangesAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            return await this.context.Products
                .Include(x => x.ProductInventories)
                .ThenInclude(x => x.Inventory)
                .FirstOrDefaultAsync(x => x.ProductId == productId);
        }

        public async Task UpdateProductAsync(Product product)
        {
            // To prevent different products from have the same name.
            if (this.context.Products.Any(
               x => x.ProductId != product.ProductId &&
               x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }

            var prod = await this.context.Products.FindAsync(product.ProductId);
            if (prod != null)
            {
                prod.ProductName = product.ProductName;
                prod.Quantity = product.Quantity;
                prod.Price = product.Price;
                prod.ProductInventories = product.ProductInventories;

                await this.context.SaveChangesAsync();
            }
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await this.context.Products.FindAsync(productId);
            if (product != null)
            {
                product.IsActive = false;
                await this.context.SaveChangesAsync();
            }
        }

    }
}
