using System.Collections.Generic;

namespace Investments.Models
{
	public class AccountStatement
	{
		public Account Account { get; set; }

		public IList<AccountStatementEntry> Entries { get; set; }

		public AccountStatement() 
		{
			Entries = new List<AccountStatementEntry>();
		}
	}
}