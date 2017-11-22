using FinanceManager.Model;
using System;
using System.IO;

namespace FinanceManager.iOS
{
    public class SQLiteIOS : ISQLite
    {
        /// <summary>
        /// Get path to database file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>Path to file database</returns>
        public string GetDatabasePath(string filename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, filename);

            return path;
        }
    }
}
