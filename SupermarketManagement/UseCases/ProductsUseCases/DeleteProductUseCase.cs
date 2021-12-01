using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        public DeleteProductUseCase(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public IProductRepository ProductRepository { get; }

        public void Execute(int productId)
        {
            ProductRepository.DeleteProduct(productId);
        }
    }
}
