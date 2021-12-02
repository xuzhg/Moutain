using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public class RecordTransactionUseCase : IRecordTransactionUseCase
    {
        public RecordTransactionUseCase(
            ITransactionRepository transactionRepository,
            IGetProductByIdUseCase getProductByIdUseCase)
        {
            TransactionRepository = transactionRepository;
            GetProductByIdUseCase = getProductByIdUseCase;
        }

        public ITransactionRepository TransactionRepository { get; }
        public IGetProductByIdUseCase GetProductByIdUseCase { get; }

        public void Execute(string cashierName, int productId, int qty)
        {
            var product = GetProductByIdUseCase.Execute(productId);

            TransactionRepository
                .Save(cashierName, productId, product.Name, product.Price.Value, product.Quantity.Value, qty);
        }
    }
}
