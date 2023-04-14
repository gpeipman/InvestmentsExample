using System;
using System.Collections.Generic;
using System.Linq;

namespace Investments
{
	public class Transaction
    {
        public string Name { get; set; }

        public List<TransactionEntry> Entries { get; set; } = new List<TransactionEntry>();

        public DateTime Time
        {
            get
            {
                return Entries.First().Time;
            }
        }
    }
}
