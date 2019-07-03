using CheckMeOutConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckMeOutConsole.Interfaces
{
	public interface ICheckout
	{
		void Scan(string code);
		void Remove(string code);
		int AmountToPay();
	}
}
