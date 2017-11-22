using SQLite;

namespace FinanceManager.Model.Tables
{
    [Table("Accumulation")]
    public class Accumulation
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
