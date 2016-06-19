#region Using Directives

using System.ComponentModel.DataAnnotations;

#endregion

namespace StockDataScraper
{
    public enum YahooTradingPeriodInterval
    {
        [Display(Name = "Daily", Description = "Daily Intervals", ShortName = "d")] D,
        [Display(Name = "Weekly", Description = "Weekly Intervals", ShortName = "w")] W,
        [Display(Name = "Monthly", Description = "Monthly Intervals", ShortName = "m")] M
    }
}