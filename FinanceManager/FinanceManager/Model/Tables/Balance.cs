using System;

namespace FinanceManager.Model.Tables
{
    public class Balance
    {
        public double Count { get; set; }
        public Currencies Currency { get; set; }
        public Category Category { get; set; }
        public History History { get; set; }

        public Balance(double count, Currencies currency, Category category)
        {
            Count = count;
            Currency = currency;
            Category = category;
            History = new History(DateTime.Now);
        }
    }
}
