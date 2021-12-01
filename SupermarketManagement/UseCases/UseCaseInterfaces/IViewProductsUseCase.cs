using CoreBusiness;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public interface IViewProductsUseCase
    {
        IEnumerable<Product> Execute();
    }
}