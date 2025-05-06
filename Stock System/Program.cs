using System;
using static Program;

class Program
{
    static void Main()
    {
        var stock = new Stock("Amazon");
        stock.Price = 100;

        var stock2 = new Stock("Apple");
        stock2.Price = 200;

        stock.OnPriceChanged += Event_OnPriceChanged;
        stock.ChangeStockPriceBy(-0.02m);
        stock.ChangeStockPriceBy(0.00m);
        stock.ChangeStockPriceBy(0.1m);
        stock.ChangeStockPriceBy(0.2m);
        stock.ChangeStockPriceBy(-0.25m);
        stock.ChangeStockPriceBy(0.00m);

        Console.WriteLine("--------------------------------------------------------");

        stock2.OnPriceChanged += Event_OnPriceChanged;
        stock2.ChangeStockPriceBy(-0.02m);
        stock2.ChangeStockPriceBy(0.00m);
        stock2.ChangeStockPriceBy(0.1m);
        stock2.ChangeStockPriceBy(0.2m);
        stock2.ChangeStockPriceBy(-0.25m);
        stock2.ChangeStockPriceBy(0.00m);

        Console.ReadKey();
    }

    private static void Event_OnPriceChanged(Stock stock, decimal oldPrice)
    {
        string result = "";
        if (stock.Price > oldPrice)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            result = "up";
        }
        else if (oldPrice > stock.Price)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            result = "down";
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            result = "Stable";
        }
        Console.WriteLine($"{stock.Stock_name} Stock: ${stock.Price} -> {result}");
    }


    public delegate void StockDelegate(Stock stock, decimal oldPrice);

    public class Stock
    {
        private string name;
        private decimal price;

        public string Stock_name
        {
            get
            {
                return name;
            }
        }

        public event StockDelegate OnPriceChanged;
        public decimal Price
        {
            get
            {
                return price;
            }

            set
            {
                this.price = value;
            }
        }

        public Stock(string stockname)
        {
            this.name = stockname;
        }

        public void ChangeStockPriceBy(decimal percent)
        {
            decimal oldPrice = this.price;
            this.price += Math.Round(this.price * percent, 2);
            if (OnPriceChanged != null)
            {
                OnPriceChanged(this, oldPrice);
            }
        }
    }
}



