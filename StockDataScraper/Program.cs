using System;

namespace StockDataScraper
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.BufferWidth = Console.BufferWidth * 5;
            Console.BufferHeight = Console.BufferHeight * 30;

            //StockDataScraper.GetAllCSIData();
            StockDataScraper.GetStockDetails();

            Console.ReadKey();
        }
    }
}