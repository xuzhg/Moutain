using System;

namespace Wrox.ProcSharp
{
	public class GoldAccount : IBankAccount
	{
		private decimal balance;
		
		public void PayIn(decimal amount)
		{
			balance += amount;
		}
		
		public bool Withdraw(decimal amount)
		{
			if (balance >= amount)
			{
				balance -= amount;
				return true;
			}
			
			Console.WriteLine("withdrawal attempt failed.");
			return false;
		}
		
		public decimal Balance
		{
			get
			{
				return balance;
			}
		}
		
		public override string ToString()
		{
			return String.Format("Gold Bank Saver: Balance = {0,6:C}", balance);
		}
	}
}