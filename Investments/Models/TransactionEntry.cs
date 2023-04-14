using System;

namespace Investments
{
	public class TransactionEntry
    {
        public string TransactionId { get; set; }
        public DateTime Time { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public TransactionTypeEnum Type { get; set; }

        public Account OwningAccount { get; set; }
        public Account OtherAccount { get; set; }
        public Securable Securable { get; set; }
        public Transaction Transaction { get; set; }
    }
}
