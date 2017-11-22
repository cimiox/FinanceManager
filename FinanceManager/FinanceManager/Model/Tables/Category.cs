using SQLite;

namespace FinanceManager.Model.Tables
{
    [Table("Category")]
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [NotNull]
        public string Name { get; set; }

        [NotNull]
        public CategoriesTypes Type { get; set; }
    }
}
