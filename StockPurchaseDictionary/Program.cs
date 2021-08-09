using System;
using System.Collections.Generic;

namespace StockPurchaseDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a simple dictionary with ticker symbols and company names in the Main method.
            Dictionary<string, string> stocks = new Dictionary<string, string>();
            stocks.Add("GM", "General Motors");
            stocks.Add("DG", "Dollar General");
            stocks.Add("TS", "Tesla");
            stocks.Add("NH", "New Horizons");
            stocks.Add("HH", "Holy Hell");

            //Create list of ValueTuples that represents stock purchases. Properties will be ticker, shares, price.
            List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>();
            purchases.Add((ticker: "GM", shares: 40, price: 150.3));
            purchases.Add((ticker: "DG", shares: 25, price: 37.5));
            purchases.Add((ticker: "TS", shares: 350, price: 221.72));
            purchases.Add((ticker: "NH", shares: 2, price: 5.49));
            purchases.Add((ticker: "HH", shares: 1250, price: 6.66));

            //Create a total ownership report that computes the total value of each stock that you have purchased.
            //This is the basic relational database join algorithm between two tables.

            //Define a new Dictionary to hold the aggregated purchase information.
            //-The key should be a string that is the full company name.
            //The value will be the valuation of each stock(price* amount)
            var portfolio = new Dictionary<string, double>();

            // Iterate over the purchases and update the valuation for each stock
            // The purchases tuple destructured the values, so the var type & name need to be declared
            foreach ((string ticker, int shares, double price) purchase in purchases)
            {
                var sum = 0d;

                //Dictionaries require a unique key. Need to see if portfolio already contains that key
                //If it does, then add that to key[ticker]'stotal cost basis by adding shared * purchase price
                if (portfolio.ContainsKey(purchase.ticker))
                {
                    sum = purchase.shares * purchase.price;
                    portfolio[purchase.ticker] += sum;
                }
                else
                //If the key does not exist, then create a new dictionary pair for the ticker and total cost basis
                {
                    sum = purchase.shares * purchase.price;
                    portfolio.Add(purchase.ticker, sum);
                }
            }

            //Create a vbariable that will show the total cost basis of all stocks purchased
            var totalValue = 0d;

            //All purchases have been stored in the portfolio. To display the data, follow the instructions below:
            //Destructure the ticker and value in the dictionary - key/value pairs in portfolio
            foreach (var (tick, value) in portfolio)
            {
                //Add each stock's value to the total portfolio value for later use
                totalValue += value;

                //We want to display the stock name, not the ticker.
                //Access stock dictionary using the ticker key to display the stock name value
                var stockName = stocks[tick];
                Console.WriteLine($"{stockName}: {value} ");
            }

            //Now show the entire portfolio cost basis so that we can later compare total profit/loss
            Console.WriteLine($"\nTotal Portfolio Cost Basis: {totalValue}");


        }
    }
}
