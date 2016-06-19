#region Using Directives

using System.ComponentModel.DataAnnotations;

#endregion

namespace StockDataScraper
{
    public enum YahooSector
    {
        [Display(Name = "Basic Materials", Description = "Basic_Materials", ShortName = "1")] Basic_Materials = 1,
        [Display(Name = "Conglomerates", Description = "Conglomerates", ShortName = "2")] Conglomerates = 2,
        [Display(Name = "Consumer Goods", Description = "Consumer Goods", ShortName = "3")] Consumer_Goods = 3,
        [Display(Name = "Financial", Description = "Financial", ShortName = "4")] Financial = 4,
        [Display(Name = "ealthcare", Description = "ealthcare", ShortName = "5")] Healthcare = 5,
        [Display(Name = "Industrial_Goods", Description = "Industrial_Goods", ShortName = "6")] Industrial_Goods = 6,
        [Display(Name = "Services", Description = "Services", ShortName = "7")] Services = 7,
        [Display(Name = "Technology", Description = "Technology", ShortName = "8")] Technology = 8,
        [Display(Name = "Utilities", Description = "Utilities", ShortName = "9")] Utilities = 9
    }
}