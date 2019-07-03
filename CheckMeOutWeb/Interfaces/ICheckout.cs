using CheckMeOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckMeOut.Interfaces
{
	public interface ICheckout
	{
		void Scan(string code);
		void Remove(string code);
		int AmountToPay();
		Dictionary<string, Stock> GetProducts();
		Dictionary<Stock, int> GetScannedProducts();
	}
}
