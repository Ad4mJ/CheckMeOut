using CheckMeOutConsole.Interfaces;
using CheckMeOutConsole.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CheckMeOutConsole
{
	public class Checkout : ICheckout
	{

		private Dictionary<string, Stock> _products = new Dictionary<string, Stock>();
		private Dictionary<Stock, int> _scannedProducts = new Dictionary<Stock, int>();

		public Checkout(Dictionary<string, Stock> stockItems)
		{
			_products = stockItems;
		}

		public void Scan(string code)
		{
			try
			{

				var stockedProduct = _products[code];
				if (_scannedProducts.ContainsKey(stockedProduct))
				{
					_scannedProducts[stockedProduct] = _scannedProducts[stockedProduct] + 1;
				}
				else 
				{
					_scannedProducts.Add(_products[code], 1);
				}
				
			}
			catch (Exception)
			{
				Console.WriteLine($"{code} not found!");
			}
		}

		public int AmountToPay()
		{
			var calculatedPrice = 0;
			foreach (var item in _scannedProducts)
			{
				calculatedPrice += item.Key.Price * item.Value;
				calculatedPrice -= item.Key.ApplyDiscount(item.Value);
			}

			return calculatedPrice;
		}

		public int PriceCheck(string code)
		{
			var calculatedPrice = 0;
			char[] products = code.ToCharArray();
			foreach (var p in products)
			{
				if (_products.ContainsKey(p.ToString()))
				{
					calculatedPrice += _products[p.ToString()].Price;
				}
			}

			return calculatedPrice;
		}

		public void ClearBasket()
		{
			_scannedProducts?.Clear();
		}

		public void Remove(string code)
		{	

			var stockedProduct = _products[code];
			if (_scannedProducts.ContainsKey(stockedProduct))
			{
				_scannedProducts.Remove(stockedProduct);
			}

		}

	}
}
