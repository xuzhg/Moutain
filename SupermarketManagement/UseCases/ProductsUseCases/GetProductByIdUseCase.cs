using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class GetProductByIdUseCase : IGetProductByIdUseCase
    {
        public GetProductByIdUseCase(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public IProductRepository ProductRepository { get; }

        public Product Execute(int productId)
        {
            return ProductRepository.GetProductById(productId);
        }
    }
}
