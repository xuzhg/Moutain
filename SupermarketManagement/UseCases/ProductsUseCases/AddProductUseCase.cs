using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class AddProductUseCase : IAddProductUseCase
    {
        public AddProductUseCase(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public IProductRepository ProductRepository { get; }

        public void Execute(Product product)
        {
            ProductRepository.AddProduct(product);
        }
    }
}
