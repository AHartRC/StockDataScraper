#region Using Directives

using System;
using System.Web;
using Newtonsoft.Json;
using StockDataScraper.Extensions;
using StockDataScraper.Helpers;

#endregion

namespace StockDataScraper
{
    public class StockResponse
    {
        public StockResponse(string exchange, string symbol, int index, decimal total)
        {
            Exchange = exchange;
            Symbol = symbol;
            Index = index;
            Total = total;
        }

        public string Exchange { get; set; }
        public string Symbol { get; set; }
        public int Index { get; set; }
        public decimal Total { get; set; }
        public TimeSpan Elapsed { get; set; }

        public decimal Remaining
        {
            get { return Total - Index; }
        }

        public string Percentage
        {
            get { return (Index / Total).ToString("P7"); }
        }

        public string Url
        {
            get
            {
                return string.Format(GoogleFinanceUrlTemplateA,
                    HttpUtility.UrlEncode(string.Format("{0}:{1}", Exchange, Symbol)));
            }
        }

        public string Response { get; set; }
        public object Schema { get; set; }
        public StockData Model { get; set; }

        public void GetResponse()
        {
            if (Exchange.IsNullOrWhiteSpace() || Symbol.IsNullOrWhiteSpace())
                return;

            Console.Write("\r{0} | {1} of {2} | {3} | {4}", DateTime.UtcNow.Ticks, Index, Total, Exchange, Symbol);

            Response = Traffic.HTTPGET(Url);
            Schema = JsonHelper.ProcessJsonSchema(Response);
            Model = JsonConvert.DeserializeObject<StockData>(Response);
        }

        #region Constants

        public const string CSIDataUrlTemplateA =
            "http://www.csidata.com/factsheets.php?format=csv&type={0}&categoryid={1}";

        public const string CSIDataUrlTemplateB =
            "http://www.csidata.com/factsheets.php?format=csv&type={0}&exchangeid={2}";

        public const string CSIDataUrlTemplateC =
            "http://www.csidata.com/factsheets.php?format=csv&type={0}&categoryid={1}&exchangeid={2}";

        public const string CSIDataUrlTemplateD = "http://www.csidata.com/factsheets.php?format=csv&type={0}";

        public const string YahooQuotesUrlTemplate = "http://download.finance.yahoo.com/d/quotes.csv?s={0}&f={1}&e=.csv";

        public const string YahooHistoricalUrlTemplate =
            "http://ichart.yahoo.com/table.csv?a={0}&b={1}&c={2}&d={3}&e={4}&f={5}&g={6}&ignore=.csv";

        public const string YahooSectorUrlTemplate = "http://biz.yahoo.com/p/csv/s_{0}{1}.csv";
        public const string YahooIndustryUrlTemplate = "http://biz.yahoo.com/p/csv/{0}{1}{2}.csv";
        public const string YahooCompanyUrlTemplate = YahooIndustryUrlTemplate;
        public const string YQLUrlTemplate = "https://query.yahooapis.com/v1/public/yql?format=json&q={0}";

        public const string GoogleFinanceUrlTemplateA = "http://www.google.com/finance?q={0}&output=json";

        public const string GoogleFinanceUrlTemplateB =
            "http://www.google.com/finance?q={0}&output=json&sq={1}&sp={2}&restype={3}&noIL={4}&num={5}";

        public const string GoogleCategoryNewsUrlTemplate =
            "http://www.google.com/finance/category_news?catid={0}&output=json";

        public const string GoogleChartUrlTemplate = "http://www.google.com/finance/chart?cht={0}&q={1}&tlf={2}";

        public const string GoogleDataUrlTemplate =
            "http://www.google.com/finance/data?cid={0}&dp={0}&catid={0}&output=json";

        public const string GoogleDomesticTrendsUrlTemplate = "http://www.google.com/finance/domestic_trends";

        public const string GooglePricesUrlTemplate =
            "http://www.google.com/finance/getprices?q={0}&x={1}&i={2}&p={3}&f=d,c,v,o,h,l&df=cpct&auto=1&ts={4}";

        public const string GoogleHistoricalUrlTemplate =
            "http://www.google.com/finance/historical?q={0}&output={1}&startdate={2}";

        public const string GoogleKDUrlTemplate =
            "http://www.google.com/finance/kd?output=json&keydevs=1&recnews=0&cid={0}";

        public const string GoogleMarketNewsUrlTemplate = "http://www.google.com/finance/market_news";
        public const string GoogleMatchUrlTemplate = "http://www.google.com/finance/match?matchtype={0}&q={1}";

        #endregion Constants
    }
}