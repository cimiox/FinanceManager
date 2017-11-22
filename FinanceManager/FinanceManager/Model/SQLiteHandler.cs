using FinanceManager.Model.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinanceManager.Model
{
    public class SQLiteHandler
    {
        /// <summary>
        /// File name of database
        /// </summary>
        private static readonly string databaseName = "Balance.db";

        /// <summary>
        /// Database instance, creates in ctor
        /// </summary>
        public SQLiteConnection Database { get; set; }

        public SQLiteHandler()
        {
            Database = new SQLiteConnection(DependencyService.Get<ISQLite>().GetDatabasePath(databaseName));
            Database.CreateTable<Balance>();
            Database.CreateTable<Accumulation>();
            Database.CreateTable<Category>();
            Database.CreateTable<History>();
        }

        /// <summary>
        /// Get all items in table
        /// </summary>
        /// <typeparam name="T">Table type</typeparam>
        /// <returns>Table Items</returns>
        public IEnumerable<T> GetItems<T>() where T : new()
        {
            return Database.Table<T>().ToList();
        }

        /// <summary>
        /// Get item from table
        /// </summary>
        /// <typeparam name="T">Table type</typeparam>
        /// <param name="id">ID item in table</param>
        /// <returns>Item from table</returns>
        public T GetItem<T>(int id) where T : new()
        {
            return Database.Get<T>(id);
        }

        /// <summary>
        /// Add item in table
        /// </summary>
        /// <typeparam name="T">Table type</typeparam>
        /// <param name="item">Item for adding in table</param>
        public void AddItem<T>(T item)
        {
            Database.Insert(item);
        }

        /// <summary>
        /// Update item in table
        /// </summary>
        /// <typeparam name="T">Table type</typeparam>
        /// <param name="item">Item who need update</param>
        public void Update<T>(T item)
        {
            Database.Update(item);
        }

        /// <summary>
        /// Delete item in table
        /// </summary>
        /// <typeparam name="T">Table type</typeparam>
        /// <param name="id">ID item in table</param>
        public void DeleteItem<T>(int id)
        {
            Database.Delete<T>(id);
        }
    }
}
