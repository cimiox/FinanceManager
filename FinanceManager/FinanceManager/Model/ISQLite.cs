using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Model
{
    public interface ISQLite
    {
        /// <summary>
        /// Get database type, need for different platforms
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>Path to file</returns>
        string GetDatabasePath(string filename);
    }
}
