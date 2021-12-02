using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public class GetTransactionUseCase : IGetTransactionUseCase
    {
        public GetTransactionUseCase(
            ITransactionRepository transactionRepository)
        {
            TransactionRepository = transactionRepository;
        }

        public ITransactionRepository TransactionRepository { get; }

        public IEnumerable<Transaction> Execute(string cashierName, DateTime startDate, DateTime endDate)
        {
            return TransactionRepository.Search(cashierName, startDate, endDate);
        }
    }
}
