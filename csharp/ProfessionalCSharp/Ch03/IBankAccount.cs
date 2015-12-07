using System;

namespace Wrox.ProcSharp
{
	public interface IBankAccount
	{
		void PayIn(decimal amount);
		bool Withdraw(decimal amount);
		decimal Balance {get;}
	}
}