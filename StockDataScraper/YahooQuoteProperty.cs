﻿#region Using Directives

using System.ComponentModel.DataAnnotations;

#endregion

namespace StockDataScraper
{
    public enum YahooQuoteProperty
    {
        [Display(Name = "Ask", ShortName = "a")] Ask,
        [Display(Name = "Average Daily Volume", ShortName = "a2")] AverageDailyVolume,
        [Display(Name = "Ask Size", ShortName = "a5")] AskSize,
        [Display(Name = "Bid", ShortName = "b")] Bid,
        [Display(Name = "Ask (Realtime)", ShortName = "b2")] AskRealtime,
        [Display(Name = "Bid (Realtime)", ShortName = "b3")] BidRealtime,
        [Display(Name = "Book Value Per Share", ShortName = "b4")] BookValuePerShare,
        [Display(Name = "Bid Size", ShortName = "b6")] BidSize,
        [Display(Name = "Change Change In Percent", ShortName = "c")] Change_ChangeInPercent,
        [Display(Name = "Change", ShortName = "c1")] Change,
        [Display(Name = "Commission", ShortName = "c3")] Commission,
        [Display(Name = "Currency", ShortName = "c4")] Currency,
        [Display(Name = "Change (Realtime)", ShortName = "c6")] ChangeRealtime,
        [Display(Name = "After Hours Change (Realtime)", ShortName = "c8")] AfterHoursChangeRealtime,
        [Display(Name = "Trailing Annual Dividend Yield", ShortName = "d")] TrailingAnnualDividendYield,
        [Display(Name = "Last Trade Date", ShortName = "d1")] LastTradeDate,
        [Display(Name = "Trade Date", ShortName = "d2")] TradeDate,
        [Display(Name = "Diluted E P S", ShortName = "e")] DilutedEPS,
        [Display(Name = "E P S Estimate Current Year", ShortName = "e7")] EPSEstimateCurrentYear,
        [Display(Name = "E P S Estimate Next Year", ShortName = "e8")] EPSEstimateNextYear,
        [Display(Name = "E P S Estimate Next Quarter", ShortName = "e9")] EPSEstimateNextQuarter,
        [Display(Name = "Trade Links Additional", ShortName = "f")] TradeLinksAdditional,
        [Display(Name = "Shares Float", ShortName = "f6")] SharesFloat,
        [Display(Name = "Days Low", ShortName = "g")] DaysLow,
        [Display(Name = "Holdings Gain Percent", ShortName = "g1")] HoldingsGainPercent,
        [Display(Name = "Annualized Gain", ShortName = "g3")] AnnualizedGain,
        [Display(Name = "Holdings Gain", ShortName = "g4")] HoldingsGain,
        [Display(Name = "Holdings Gain Percent (Realtime)", ShortName = "g5")] HoldingsGainPercentRealtime,
        [Display(Name = "Holdings Gain (Realtime)", ShortName = "g6")] HoldingsGainRealtime,
        [Display(Name = "Days High", ShortName = "h")] DaysHigh,
        [Display(Name = "More Info", ShortName = "i")] MoreInfo,
        [Display(Name = "Order Book (Realtime)", ShortName = "i5")] OrderBookRealtime,
        [Display(Name = "Year Low", ShortName = "j")] YearLow,
        [Display(Name = "Market Capitalization", ShortName = "j1")] MarketCapitalization,
        [Display(Name = "Shares Outstanding", ShortName = "j2")] SharesOutstanding,
        [Display(Name = "Market Cap (Realtime)", ShortName = "j3")] MarketCapRealtime,
        [Display(Name = "E B I T D A", ShortName = "j4")] EBITDA,
        [Display(Name = "Change From Year Low", ShortName = "j5")] ChangeFromYearLow,
        [Display(Name = "Percent Change From Year Low", ShortName = "j6")] PercentChangeFromYearLow,
        [Display(Name = "Year High", ShortName = "k")] YearHigh,
        [Display(Name = "Last Trade (Realtime) With Time", ShortName = "k1")] LastTradeRealtimeWithTime,
        [Display(Name = "Change In Percent (Realtime)", ShortName = "k2")] ChangeInPercentRealtime,
        [Display(Name = "Last Trade Size", ShortName = "k3")] LastTradeSize,
        [Display(Name = "Change From Year High", ShortName = "k4")] ChangeFromYearHigh,
        [Display(Name = "Change In Percent From Year High", ShortName = "k5")] ChangeInPercentFromYearHigh,
        [Display(Name = "Last Trade With Time", ShortName = "l")] LastTradeWithTime,
        [Display(Name = "Last Trade Price Only", ShortName = "l1")] LastTradePriceOnly,
        [Display(Name = "High Limit", ShortName = "l2")] HighLimit,
        [Display(Name = "Low Limit", ShortName = "l3")] LowLimit,
        [Display(Name = "Days Range", ShortName = "m")] DaysRange,
        [Display(Name = "Days Range (Realtime)", ShortName = "m2")] DaysRangeRealtime,
        [Display(Name = "Fiftyday Moving Average", ShortName = "m3")] FiftydayMovingAverage,
        [Display(Name = "Two Hundredday Moving Average", ShortName = "m4")] TwoHundreddayMovingAverage,
        [Display(Name = "Change From Two Hundredday Moving Average", ShortName = "m5")] ChangeFromTwoHundreddayMovingAverage,
        [Display(Name = "Percent Change From Two Hundredday Moving Average", ShortName = "m6")] PercentChangeFromTwoHundreddayMovingAverage,
        [Display(Name = "Change From Fiftyday Moving Average", ShortName = "m7")] ChangeFromFiftydayMovingAverage,
        [Display(Name = "Percent Change From Fiftyday Moving Average", ShortName = "m8")] PercentChangeFromFiftydayMovingAverage,
        [Display(Name = "Name", ShortName = "n")] Name,
        [Display(Name = "Notes", ShortName = "n4")] Notes,
        [Display(Name = "Open", ShortName = "o")] Open,
        [Display(Name = "Previous Close", ShortName = "p")] PreviousClose,
        [Display(Name = "Price Paid", ShortName = "p1")] PricePaid,
        [Display(Name = "Change In Percent", ShortName = "p2")] ChangeInPercent,
        [Display(Name = "Price Sales", ShortName = "p5")] PriceSales,
        [Display(Name = "Price Book", ShortName = "p6")] PriceBook,
        [Display(Name = "Ex Dividend Date", ShortName = "q")] ExDividendDate,
        [Display(Name = "P E Ratio", ShortName = "r")] PERatio,
        [Display(Name = "Dividend Pay Date", ShortName = "r1")] DividendPayDate,
        [Display(Name = "P E Ratio (Realtime)", ShortName = "r2")] PERatioRealtime,
        [Display(Name = "P E G Ratio", ShortName = "r5")] PEGRatio,
        [Display(Name = "Price E P S Estimate Current Year", ShortName = "r6")] PriceEPSEstimateCurrentYear,
        [Display(Name = "Price E P S Estimate Next Year", ShortName = "r7")] PriceEPSEstimateNextYear,
        [Display(Name = "Symbol", ShortName = "s")] Symbol,
        [Display(Name = "Shares Owned", ShortName = "s1")] SharesOwned,
        [Display(Name = "Revenue", ShortName = "s6")] Revenue,
        [Display(Name = "Short Ratio", ShortName = "s7")] ShortRatio,
        [Display(Name = "Last Trade Time", ShortName = "t1")] LastTradeTime,
        [Display(Name = "Trade Links", ShortName = "t6")] TradeLinks,
        [Display(Name = "Ticker Trend", ShortName = "t7")] TickerTrend,
        [Display(Name = "Oneyr Target Price", ShortName = "t8")] OneyrTargetPrice,
        [Display(Name = "Volume", ShortName = "v")] Volume,
        [Display(Name = "Holdings Value", ShortName = "v1")] HoldingsValue,
        [Display(Name = "Holdings Value (Realtime)", ShortName = "v7")] HoldingsValueRealtime,
        [Display(Name = "Year Range", ShortName = "w")] YearRange,
        [Display(Name = "Days Value Change", ShortName = "w1")] DaysValueChange,
        [Display(Name = "Days Value Change (Realtime)", ShortName = "w4")] DaysValueChangeRealtime,
        [Display(Name = "Stock Exchange", ShortName = "x")] StockExchange,
        [Display(Name = "Trailing Annual Dividend Yield In Percent", ShortName = "y")] TrailingAnnualDividendYieldInPercent
    }
}