
namespace FinanceManager.Model.Tables
{
    public class Category
    {
        public string Name { get; set; }
        public CategoriesTypes Type { get; set; }

        public Category(string name, CategoriesTypes type)
        {
            Name = name;
            Type = type;
        }
    }
}
