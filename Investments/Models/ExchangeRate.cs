using System;

namespace Investments
{
	public class ExchangeRate
    {
        public DateTime Date { get; set; }
        public decimal Rate { get; set; }

        public Securable From { get; set; }
        public Securable To { get; set; }

		public override bool Equals(object o)
		{
			if (o == null)
			{
				return false;
			}

			var otherRate = o as ExchangeRate;
			if (otherRate == null)
			{
				return false;
			}

			return (Date == otherRate.Date &&
					From == otherRate.From &&
					To == otherRate.To);
		}

		public static bool operator ==(ExchangeRate v1, ExchangeRate v2)
		{
			return v1.Equals(v2);
		}

		public static bool operator !=(ExchangeRate v1, ExchangeRate v2)
		{
			return !v1.Equals(v2);
		}

		public override int GetHashCode()
		{
			int hash = 27;

			hash = (13 * hash) + Date.GetHashCode();
			hash = (13 * hash) + From.GetHashCode();
			hash = (13 * hash) + To.GetHashCode();

			return hash;
		}
	}
}