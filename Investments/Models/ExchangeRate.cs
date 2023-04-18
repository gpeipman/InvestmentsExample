using System;

namespace Investments
{
	public class ExchangeRate
    {
        public DateTime Date { get; set; }
        public decimal Rate { get; set; }

        public Securable From { get; set; }
        public Securable To { get; set; }
    }
}
