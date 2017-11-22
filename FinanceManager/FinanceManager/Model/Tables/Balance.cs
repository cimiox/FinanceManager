
using SQLite;
using System;

namespace FinanceManager.Model.Tables
{
    [Table("Balance")]
    public class Balance
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [NotNull]
        public double Count { get; set; }

        [Indexed, NotNull]
        public int CategoryID { get; set; }

        [Indexed, NotNull]
        public int HistoryID { get; set; }
    }
}
