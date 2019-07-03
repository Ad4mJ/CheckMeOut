using System;

namespace CheckMeOutConsole
{
	class Program
	{
		static void Main(string[] args)
		{

			Checkout Checkout = new Checkout(FakeWarehouse.Products());

			Checkout.Scan("A");
			Console.WriteLine("Cost: 50.");
			Console.WriteLine("To Pay: {0}", Checkout.AmountToPay());
			Checkout.ClearBasket();
			Console.WriteLine();

			Checkout.Scan("A");
			Checkout.Scan("B");
			Checkout.Scan("B");
			Console.WriteLine("Cost: 95.");
			Console.WriteLine("To Pay: {0}", Checkout.AmountToPay());
			Checkout.ClearBasket();
			Console.WriteLine();


			Checkout.Scan("A");
			Checkout.Scan("B");
			Checkout.Scan("X");
			Console.WriteLine("Cost: 80.");
			Console.WriteLine("To Pay: {0}", Checkout.AmountToPay());
			Checkout.ClearBasket();
			Console.WriteLine();

			Console.ReadKey();

			Console.ReadKey();
		}
	}
}
