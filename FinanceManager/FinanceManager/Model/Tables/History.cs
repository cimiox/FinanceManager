using SQLite;
using System;

namespace FinanceManager.Model.Tables
{
    [Table("History")]
    public class History
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [NotNull]
        public DateTime ChangesTime { get; set; }
    }
}
