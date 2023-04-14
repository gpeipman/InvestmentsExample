using System.Collections.Generic;
using System.Linq;

namespace Investments
{
	public class InstitutionsCollection : List<Institution>
	{
		public Institution GetByName(string name)
		{
			return this.Where(institution => institution.Name?.ToLower() == name)
					   .FirstOrDefault();
		}
	}
}
