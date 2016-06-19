#region Using Directives

using System;
using System.Collections.Generic;

#endregion

namespace StockDataScraper
{
    public class CSIDataRecord
    {
        public CSIDataRecord()
        {
            CSIDataCSVRecords = new HashSet<CSIDataCSVRecord>();
        }

        public int ID { get; set; }
        public string FilePath { get; set; }
        public string Url { get; set; }
        public CSIDataType? DataType { get; set; }
        public CSIDataCategory? Category { get; set; }
        public CSIDataExchange? Exchange { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<CSIDataCSVRecord> CSIDataCSVRecords { get; set; }
    }
}