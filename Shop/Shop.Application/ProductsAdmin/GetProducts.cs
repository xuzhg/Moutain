using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin
{
    public class GetProducts
    {
        public GetProducts(ApplicationDbContext ctx)
        {
            Ctx = ctx;
        }

        public ApplicationDbContext Ctx { get; }

        public IEnumerable<ProductViewModel> Do() =>
            Ctx.Products.ToList().Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                //Description = x.Description,
               // Value = $"$ {x.Value.ToString("N2")}"
               Value = x.Value
            });

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }

            //public string Description { get; set; }

            public decimal Value { get; set; }
        }
    }
}
