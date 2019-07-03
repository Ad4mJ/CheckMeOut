using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckMeOut.Models
{
	public class Stock
	{
		public string SKU { get; private set; }
		public int Price { get; set; }
		public int DiscountPrice { get; set; }
		public int QuantityRequired { get; set; }

		public Stock(string stockKeepingUnit, int unitPrice, int discountPrice = 0, int quantityRequired = 0)
		{
			SKU = stockKeepingUnit;
			Price = unitPrice;

			DiscountPrice = discountPrice;
			QuantityRequired = quantityRequired;
		}

		public int ApplyDiscount(int qty)
		{

			if (DiscountPrice == 0 || qty < QuantityRequired)
				return 0;

			return (qty / QuantityRequired) * ((Price * QuantityRequired) - DiscountPrice);			
		}
	}
}
