using System.Collections.Generic;
using System.Linq;

namespace Investments
{
	public class SecurablesCollection : List<Securable>
    {
        public Securable GetByTicker(string ticker)
        {
            return this.Where(securable => securable.Ticker.ToUpper() == ticker.ToUpper())
                       .FirstOrDefault();
        }
    }
}