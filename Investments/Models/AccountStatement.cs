using System.Collections.Generic;

namespace Investments.Models
{
	public class AccountStatement
	{
		public Account Account { get; set; }
		public AccountStatementHeader Header { get; private set; }
		public IList<AccountStatementEntry> Entries { get; set; }

		public AccountStatement() 
		{
			Header = new AccountStatementHeader();
			Entries = new List<AccountStatementEntry>();
		}
	}
}