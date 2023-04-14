using System.Collections.Generic;

namespace Investments.Data
{
	public static class TransactionsGenerator
	{
		public static IList<Transaction> GetTransactions()
		{
			var list = new List<Transaction>
			{
				new Transaction { Name = "10.04.2023 MSFT Ost", },
				new Transaction { Name = "14.04.2023 MSFT Ost", }
			};

			return list;
		}
	}
}