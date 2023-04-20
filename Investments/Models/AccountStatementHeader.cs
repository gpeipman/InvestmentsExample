using System;

namespace Investments.Models
{
	public class AccountStatementHeader
	{
		public DateTime? FromDate { get; set; }
		public DateTime? ToDate { get; set;}

		public decimal StartingBalance { get; set; }
		public decimal Balance { get; set; }
	}
}