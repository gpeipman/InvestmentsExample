using System;

namespace Investments.Models
{
	public class AccountStatementEntry
	{
		public string TransactionId { get; set; }
		public DateTime Time { get; set; }
		public decimal Amount { get; set; }
		public string Description { get; set; }
		public decimal Balance { get; set; }
		
		public Securable Securable { get; set; }
		public Account OwningAccount { get; set; }
		public Account OtherAccount { get; set; }
	}
}