using CheckMeOutConsole;
using Xunit;

namespace CheckMeOut.Test
{
	public class CheckoutTests
	{

		Checkout Checkout = new Checkout(FakeWarehouse.Products());

		[Fact]
		public void PriceCheck()
		{
			Checkout.Scan("A");
			Checkout.Scan("B");
			Checkout.Scan("C");
			Checkout.Scan("D");
			Checkout.Scan("D");
			Assert.Equal(0, Checkout.PriceCheck(""));
			Assert.Equal(50, Checkout.PriceCheck("A"));
			Assert.Equal(80, Checkout.PriceCheck("AB"));
			Assert.Equal(115, Checkout.PriceCheck("ABCD"));

			Checkout.ClearBasket();
		}

		[Fact]
		public void DiscountedPriceCheck()
		{
			Checkout.Scan("A");
			Checkout.Scan("A");
			Checkout.Scan("A");
			Assert.Equal(130, Checkout.AmountToPay());

			Checkout.ClearBasket();
		}

		[Fact]
		public void CheckoutTally()
		{
			Checkout.Scan("A");
			Checkout.Scan("B");
			Checkout.Scan("C");
			Checkout.Scan("D");
			Assert.Equal(115, Checkout.AmountToPay());

			Checkout.ClearBasket();
		}

		[Fact]
		public void RemoveItem()
		{
			Checkout.Scan("A");
			Checkout.Scan("B");
			Checkout.Scan("C");
			Checkout.Scan("D");
			Checkout.Remove("A");
			Assert.Equal(65, Checkout.AmountToPay());

			Checkout.ClearBasket();
		}

		[Fact]
		public void NotFound()
		{
			Checkout.Scan("X");
			Assert.Equal(0, Checkout.AmountToPay());

			Checkout.ClearBasket();
		}
	}
}

