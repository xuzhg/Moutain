using System;
using Wrox.ProcSharp;

namespace Wrox
{
	public class Program
	{
		public static void Main()
		{
			IBankAccount venusAccount = new SaverAccount();
			IBankAccount jupiterAccount = new GoldAccount();
			
			venusAccount.PayIn(200);
			venusAccount.Withdraw(100);
			Console.WriteLine(venusAccount.ToString());
			
			jupiterAccount.PayIn(500);
			jupiterAccount.Withdraw(600);
			jupiterAccount.Withdraw(100);
			Console.WriteLine(jupiterAccount.ToString());
			
			ITransferBankAccount jupiterAccount2 = new CurrentAccount();
			jupiterAccount2.PayIn(500);
			jupiterAccount2.TransferTo(venusAccount, 100);
			Console.WriteLine(venusAccount.ToString());
			Console.WriteLine(jupiterAccount2.ToString());
		}
	}
}