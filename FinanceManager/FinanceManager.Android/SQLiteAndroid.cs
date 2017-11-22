using FinanceManager.Model;
using System.IO;

namespace FinanceManager.Droid
{
    public class SQLiteAndroid : ISQLite
    {
        public SQLiteAndroid()
        {

        }

        /// <summary>
        /// Get path to database file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>Path to file database</returns>
        public string GetDatabasePath(string filename)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, filename);
            return path;
        }
    }
}