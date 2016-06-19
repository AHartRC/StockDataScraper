#region Using Directives

using System.Data.Entity;

#endregion

namespace StockDataScraper
{
    public class StockDataEntities : DbContext
    {
        public StockDataEntities() : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<CSIDataCSVRecord> CSIDataCSVRecords { get; set; }
        public virtual DbSet<CSIDataRecord> CSIDataRecords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CSIDataRecordMap());
            modelBuilder.Configurations.Add(new CSIDataCSVRecordMap());
        }
    }
}