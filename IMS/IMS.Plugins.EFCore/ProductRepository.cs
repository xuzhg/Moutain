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

        public async Task<List<Product>> GetProductsByName(string name = "")
        {
            return await this.context.Products.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
               string.IsNullOrWhiteSpace(name)).ToListAsync();
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
    }
}
