
using System;

namespace FinanceManager.Model.Tables
{
    public class History
    {
        public DateTime ChangesTime { get; set; }

        public History(DateTime changesTime)
        {
            ChangesTime = changesTime;
        }
    }
}
