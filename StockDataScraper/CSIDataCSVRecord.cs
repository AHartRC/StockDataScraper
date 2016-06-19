#region Using Directives

using System;

#endregion

namespace StockDataScraper
{
    public class CSIDataCSVRecord
    {
        public int ID { get; set; }
        public int CSIDataRecordID { get; set; }
        public string ChildExchange { get; set; }
        public string CloseField { get; set; }
        public int? CommercialCsiNumber { get; set; }
        public int? CommercialDeliveryMonth { get; set; }
        public string ContractSize { get; set; }
        public string ConversionFactor { get; set; }
        public int? ConversionFactorCode { get; set; }
        public int? CsiNumber { get; set; }
        public string Currency { get; set; }
        public string DeliveryMonths { get; set; }
        public string DivideStrike { get; set; }
        public DateTime? EndDate { get; set; }
        public string Exchange { get; set; }
        public string ExchangeSymbol { get; set; }
        public string Footnote { get; set; }
        public decimal? FullPointValue { get; set; }
        public bool? HasCurrentDayOpenInterest { get; set; }
        public bool? HasCurrentDayVolume { get; set; }
        public bool? HasImplied5 { get; set; }
        public bool? HasImplied5Prices { get; set; }
        public bool? HasImplied5Strikes { get; set; }
        public bool? HasKnownExpirationDates { get; set; }
        public string Industry { get; set; }
        public bool? IsActive { get; set; }
        public long? LastTotalVolume { get; set; }
        public long? LastVolume { get; set; }
        public string LinkSymbol { get; set; }
        public decimal? MinimumTick { get; set; }
        public string Name { get; set; }
        public decimal? OhlcOffset { get; set; }
        public string PreSwitchCF { get; set; }
        public string Sector { get; set; }
        public string SessionGroup { get; set; }
        public string SessionType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? SwitchCfDate { get; set; }
        public string Symbol { get; set; }
        public string SymbolCommercial { get; set; }
        public string SymbolUA { get; set; }
        public decimal? TerminalPointValue { get; set; }
        public decimal? TickValue { get; set; }
        public string TradingTime { get; set; }
        public string Type { get; set; }
        public int? UACsiNumber { get; set; }
        public string Units { get; set; }

        public virtual CSIDataRecord CSIDataRecord { get; set; }
    }
}