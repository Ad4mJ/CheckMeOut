using CheckMeOut.Interfaces;
using CheckMeOut.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CheckMeOut
{
	public class Checkout : ICheckout
	{

		private Dictionary<string, Stock> _products = new Dictionary<string, Stock>();
		private Dictionary<Stock, int> _scannedProducts = new Dictionary<Stock, int>();

		public Checkout(Dictionary<string, Stock> stockItems)
		{
			_products = stockItems;
		}

		public Dictionary<string, Stock> GetProducts()
		{
			return _products;
		}

		public Dictionary<Stock, int> GetScannedProducts()
		{
			return _scannedProducts;
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
				//TODO Item not found;
				Debug.WriteLine("Item Not Found");
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

		public int PriceCheck(string item)
		{
			var calculatedPrice = 0;
			char[] items = item.ToCharArray();
			foreach (var i in items)
			{
				if (_products.ContainsKey(i.ToString()))
				{
					calculatedPrice += _products[i.ToString()].Price;
				}
			}

			return calculatedPrice;
		}

		public void Clear()
		{
			_scannedProducts.Clear();
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
