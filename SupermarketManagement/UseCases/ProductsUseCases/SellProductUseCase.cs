using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        public SellProductUseCase(IProductRepository productRepository,
            IRecordTransactionUseCase recordTransactionUseCase)
        {
            ProductRepository = productRepository;
            RecordTransactionUseCase = recordTransactionUseCase;
        }

        public IProductRepository ProductRepository { get; }
        public IRecordTransactionUseCase RecordTransactionUseCase { get; }

        public void Execute(string cashierName, int productId, int qtyToSell)
        {
            var product = ProductRepository.GetProductById(productId);
            if (product == null)
            {
                return;
            }

            RecordTransactionUseCase.Execute(cashierName, productId, qtyToSell);

            product.Quantity -= qtyToSell;
            ProductRepository.UpdateProduct(product);
        }
    }
}
