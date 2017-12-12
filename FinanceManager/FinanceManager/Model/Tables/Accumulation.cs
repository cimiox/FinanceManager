namespace FinanceManager.Model.Tables
{
    public class Accumulation
    {
        public int ID { get; set; }
        public double Count { get; set; }
        public Category Category { get; set; }
        public History History { get; set; }

        public Accumulation(double count, Category category, History history)
        {
            Count = count;
            Category = category;
            History = history;
        }
    }
}
