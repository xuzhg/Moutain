using System;

namespace Wrox.ProcSharp
{
	public interface ITransferBankAccount : IBankAccount
	{
		bool TransferTo(IBankAccount destination, decimal amount);
	}
}