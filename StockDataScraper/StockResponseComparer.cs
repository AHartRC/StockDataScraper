#region Using Directives

using System.Collections.Generic;

#endregion

namespace StockDataScraper
{
    public class StockResponseComparer : IEqualityComparer<StockResponse>
    {
        public bool Equals(StockResponse x, StockResponse y)
        {
            return x.Url == y.Url;
            //return x.Exchange == y.Exchange &&
            //       x.Symbol == y.Symbol;
        }

        public int GetHashCode(StockResponse obj)
        {
            return obj.GetHashCode();
        }
    }
}