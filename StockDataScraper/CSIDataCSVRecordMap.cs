#region Using Directives

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

#endregion

namespace StockDataScraper
{
    public class CSIDataCSVRecordMap : EntityTypeConfiguration<CSIDataCSVRecord>
    {
        public CSIDataCSVRecordMap()
        {
            ToTable("CSIDataCSVRecord", "dbo");

            HasKey(k => k.ID);

            Property(p => p.ID)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("ID")
                .HasColumnOrder(1)
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasParameterName("ID")
                .IsOptional()
                .IsRequired();

            Property(p => p.CSIDataRecordID)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("CSIDataRecordID")
                .HasColumnOrder(2)
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("CSIDataRecordID")
                .IsOptional()
                .IsRequired();

            Property(p => p.ChildExchange)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("ChildExchange")
                .HasColumnOrder(3)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(32)
                .HasParameterName("ChildExchange")
                .IsOptional();

            Property(p => p.CloseField)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("CloseField")
                .HasColumnOrder(4)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(16)
                .HasParameterName("CloseField")
                .IsOptional();

            Property(p => p.CommercialCsiNumber)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("CommercialCsiNumber")
                .HasColumnOrder(5)
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("CommercialCsiNumber")
                .IsOptional();

            Property(p => p.CommercialDeliveryMonth)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("CommercialDeliveryMonth")
                .HasColumnOrder(6)
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("CommercialDeliveryMonth")
                .IsOptional();

            Property(p => p.ContractSize)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("ContractSize")
                .HasColumnOrder(7)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(128)
                .HasParameterName("ContractSize")
                .IsOptional();

            Property(p => p.ConversionFactor)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("ConversionFactor")
                .HasColumnOrder(8)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(32)
                .HasParameterName("ConversionFactor")
                .IsOptional();

            Property(p => p.ConversionFactorCode)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("ConversionFactorCode")
                .HasColumnOrder(9)
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("ConversionFactorCode")
                .IsOptional();

            Property(p => p.CsiNumber)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("CsiNumber")
                .HasColumnOrder(10)
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("CsiNumber")
                .IsOptional();

            Property(p => p.Currency)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("Currency")
                .HasColumnOrder(11)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(4)
                .HasParameterName("Currency")
                .IsOptional();

            Property(p => p.DeliveryMonths)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("DeliveryMonths")
                .HasColumnOrder(12)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(16)
                .HasParameterName("DeliveryMonths")
                .IsOptional();

            Property(p => p.DivideStrike)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("DivideStrike")
                .HasColumnOrder(13)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(32)
                .HasParameterName("DivideStrike")
                .IsOptional();

            Property(p => p.EndDate)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("EndDate")
                .HasColumnOrder(14)
                .HasColumnType("DATE")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("EndDate")
                .IsOptional();

            Property(p => p.Exchange)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("Exchange")
                .HasColumnOrder(15)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(8)
                .HasParameterName("Exchange")
                .IsOptional();

            Property(p => p.ExchangeSymbol)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("ExchangeSymbol")
                .HasColumnOrder(16)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(16)
                .HasParameterName("ExchangeSymbol")
                .IsOptional();

            Property(p => p.Footnote)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("Footnote")
                .HasColumnOrder(17)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(1024)
                .HasParameterName("Footnote")
                .IsOptional();

            Property(p => p.FullPointValue)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("FullPointValue")
                .HasColumnOrder(18)
                .HasColumnType("DECIMAL")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("FullPointValue")
                .IsOptional();

            Property(p => p.HasCurrentDayOpenInterest)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("HasCurrentDayOpenInterest")
                .HasColumnOrder(19)
                .HasColumnType("BIT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("HasCurrentDayOpenInterest")
                .IsOptional();

            Property(p => p.HasCurrentDayVolume)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("HasCurrentDayVolume")
                .HasColumnOrder(20)
                .HasColumnType("BIT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("HasCurrentDayVolume")
                .IsOptional();

            Property(p => p.HasImplied5)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("HasImplied5")
                .HasColumnOrder(21)
                .HasColumnType("BIT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("HasImplied5")
                .IsOptional();

            Property(p => p.HasImplied5Prices)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("HasImplied5Prices")
                .HasColumnOrder(22)
                .HasColumnType("BIT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("HasImplied5Prices")
                .IsOptional();

            Property(p => p.HasImplied5Strikes)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("HasImplied5Strikes")
                .HasColumnOrder(23)
                .HasColumnType("BIT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("HasImplied5Strikes")
                .IsOptional();

            Property(p => p.HasKnownExpirationDates)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("HasKnownExpirationDates")
                .HasColumnOrder(24)
                .HasColumnType("BIT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("HasKnownExpirationDates")
                .IsOptional();

            Property(p => p.Industry)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("Industry")
                .HasColumnOrder(25)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(64)
                .HasParameterName("Industry")
                .IsOptional();

            Property(p => p.IsActive)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("IsActive")
                .HasColumnOrder(26)
                .HasColumnType("BIT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("IsActive")
                .IsOptional();

            Property(p => p.LastTotalVolume)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("LastTotalVolume")
                .HasColumnOrder(27)
                .HasColumnType("BIGINT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("LastTotalVolume")
                .IsOptional();

            Property(p => p.LastVolume)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("LastVolume")
                .HasColumnOrder(28)
                .HasColumnType("BIGINT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("LastVolume")
                .IsOptional();

            Property(p => p.LinkSymbol)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("LinkSymbol")
                .HasColumnOrder(29)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(32)
                .HasParameterName("LinkSymbol")
                .IsOptional();

            Property(p => p.MinimumTick)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("MinimumTick")
                .HasColumnOrder(30)
                .HasColumnType("DECIMAL")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("MinimumTick")
                .IsOptional();

            Property(p => p.Name)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("Name")
                .HasColumnOrder(31)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(128)
                .HasParameterName("Name")
                .IsOptional();

            Property(p => p.OhlcOffset)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("OhlcOffset")
                .HasColumnOrder(32)
                .HasColumnType("DECIMAL")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("OhlcOffset")
                .IsOptional();

            Property(p => p.PreSwitchCF)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("PreSwitchCF")
                .HasColumnOrder(33)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(32)
                .HasParameterName("PreSwitchCF")
                .IsOptional();

            Property(p => p.Sector)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("Sector")
                .HasColumnOrder(34)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(32)
                .HasParameterName("Sector")
                .IsOptional();

            Property(p => p.SessionGroup)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("SessionGroup")
                .HasColumnOrder(35)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(16)
                .HasParameterName("SessionGroup")
                .IsOptional();

            Property(p => p.SessionType)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("SessionType")
                .HasColumnOrder(36)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(8)
                .HasParameterName("SessionType")
                .IsOptional();

            Property(p => p.StartDate)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("StartDate")
                .HasColumnOrder(37)
                .HasColumnType("DATE")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("StartDate")
                .IsOptional();

            Property(p => p.SwitchCfDate)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("SwitchCfDate")
                .HasColumnOrder(38)
                .HasColumnType("DATE")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("SwitchCfDate")
                .IsOptional();

            Property(p => p.Symbol)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("Symbol")
                .HasColumnOrder(39)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(16)
                .HasParameterName("Symbol")
                .IsOptional();

            Property(p => p.SymbolCommercial)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("SymbolCommercial")
                .HasColumnOrder(40)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(16)
                .HasParameterName("SymbolCommercial")
                .IsOptional();

            Property(p => p.SymbolUA)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("SymbolUA")
                .HasColumnOrder(41)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(16)
                .HasParameterName("SymbolUA")
                .IsOptional();

            Property(p => p.TerminalPointValue)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("TerminalPointValue")
                .HasColumnOrder(42)
                .HasColumnType("DECIMAL")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("TerminalPointValue")
                .IsOptional();

            Property(p => p.TickValue)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("TickValue")
                .HasColumnOrder(43)
                .HasColumnType("DECIMAL")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("TickValue")
                .IsOptional();

            Property(p => p.TradingTime)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("TradingTime")
                .HasColumnOrder(44)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(16)
                .HasParameterName("TradingTime")
                .IsOptional();

            Property(p => p.Type)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("Type")
                .HasColumnOrder(45)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(32)
                .HasParameterName("TradingTime")
                .IsOptional();

            Property(p => p.UACsiNumber)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("UACsiNumber")
                .HasColumnOrder(46)
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("UACsiNumber")
                .IsOptional();

            Property(p => p.Units)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("Units")
                .HasColumnOrder(47)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(64)
                .HasParameterName("Units")
                .IsOptional();

            HasRequired(r => r.CSIDataRecord)
                .WithMany(m => m.CSIDataCSVRecords)
                .HasForeignKey(fk => fk.CSIDataRecordID)
                .WillCascadeOnDelete(true);
        }
    }
}