using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.View
{

    public class LeftMenuMenuItem
    {
        public LeftMenuMenuItem()
        {
            TargetType = typeof(LeftMenuDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}