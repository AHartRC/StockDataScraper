#region Using Directives

using System.ComponentModel.DataAnnotations;

#endregion

namespace StockDataScraper
{
    public enum YahooMarketQuoteProperty
    {
        [Display(Name = "Name", Description = "Name", ShortName = "coname")] coname,
        [Display(Name = "DividendYieldPercent", Description = "Dividend Yield Percentage", ShortName = "yie")] yie,
        [Display(Name = "LongTermDebtToEquity", Description = "Long-Term Debt/Equity Ratio", ShortName = "qto")] qto,

        [Display(Name = "MarketCapitalizationInMillion", Description = "Market Capitalization (In Millions)",
            ShortName = "mkt")] mkt,
        [Display(Name = "NetProfitMarginPercent", Description = "Net-Profit Margin Percentage", ShortName = "qpm")] qpm,

        [Display(Name = "OneDayPriceChangePercent", Description = " One-day Price Change Percentage", ShortName = "pr1")
        ] pr1,
        [Display(Name = "PriceEarningsRatio", Description = "Price/Earnings Ratio", ShortName = "pee")] pee,
        [Display(Name = "PriceToBookValue", Description = "Price-to-Book Value", ShortName = "pri")] pri,
        [Display(Name = "PriceToFreeCashFlow", Description = "Price to Free Cash Flow", ShortName = "prf")] prf,
        [Display(Name = "ReturnOnEquityPercent", Description = "Return on Equity Percentage", ShortName = "ttm")] ttm
    }
}