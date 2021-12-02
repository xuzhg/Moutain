using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class ViewProductsByCategoryId : IViewProductsByCategoryId
    {
        public ViewProductsByCategoryId(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public IProductRepository ProductRepository { get; }

        public IEnumerable<Product> Execute(int categoryId)
        {
            return ProductRepository.GetProductsByCategoryId(categoryId);
        }
    }
}
