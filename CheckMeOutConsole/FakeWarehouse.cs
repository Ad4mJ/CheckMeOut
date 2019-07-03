using CheckMeOutConsole.Models;
using System.Collections.Generic;

namespace CheckMeOutConsole
{
	public static class FakeWarehouse
	{
		public static Dictionary<string, Stock> Products()
		{
			return new Dictionary<string, Stock>
			{
				{ "A", new Stock("A", 50, 130, 3) },
				{ "B", new Stock("B", 30, 45, 2) },
				{ "C", new Stock("C", 20) },
				{ "D", new Stock("D", 15) }
			};
		}
	}
}
