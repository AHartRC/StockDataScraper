#region Using Directives

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

#endregion

namespace StockDataScraper
{
    public class CSIDataRecordMap : EntityTypeConfiguration<CSIDataRecord>
    {
        public CSIDataRecordMap()
        {
            ToTable("CSIDataRecord", "dbo");

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

            Property(p => p.FilePath)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("FilePath")
                .HasColumnOrder(2)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(128)
                .HasParameterName("FilePath")
                .IsOptional();

            Property(p => p.Url)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("Url")
                .HasColumnOrder(3)
                .HasColumnType("NVARCHAR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(128)
                .HasParameterName("Url")
                .IsOptional();

            Property(p => p.DataType)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("DataType")
                .HasColumnOrder(4)
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("DataType")
                .IsOptional();

            Property(p => p.Category)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("Category")
                .HasColumnOrder(5)
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("Category")
                .IsOptional();

            Property(p => p.Exchange)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("Exchange")
                .HasColumnOrder(6)
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("Exchange")
                .IsOptional();

            Property(p => p.DateCreated)
                //.HasColumnAnnotation("IDX_INDEX_NAME", "")
                .HasColumnName("DateCreated")
                .HasColumnOrder(7)
                .HasColumnType("DATETIME")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasParameterName("DateCreated")
                .IsRequired();

            HasMany(m => m.CSIDataCSVRecords)
                .WithRequired(r => r.CSIDataRecord)
                .HasForeignKey(fk => fk.CSIDataRecordID)
                .WillCascadeOnDelete(true);
        }
    }
}