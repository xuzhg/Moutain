using CoreBusiness;
using System;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class ViewProductsUseCase : IViewProductsUseCase
    {
        public ViewProductsUseCase(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public IProductRepository ProductRepository { get; }

        public IEnumerable<Product> Execute()
        {
            return ProductRepository.GetProducts();
        }
    }
}
