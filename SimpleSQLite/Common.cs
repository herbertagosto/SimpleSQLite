using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSQLite
{
    public static class Common
    {
        /// <summary>
        /// Check if table exists in DB file
        /// </summary>
        /// <typeparam name="T">Class name</typeparam>
        /// <param name="connection">SQLiteConnection</param>
        /// <returns>bool</returns>
        public static bool IsTableExists<T>(SQLiteConnection connection)
        {
            const string cmdText = "SELECT name FROM sqlite_master WHERE type='table' AND name=?";
            var cmd = connection.CreateCommand(cmdText, typeof(T).Name);
            return cmd.ExecuteScalar<string>() != null;
        }
        /// <summary>
        /// Save table to DB file
        /// </summary>
        /// <typeparam name="T">Class name</typeparam>
        /// <param name="connection">SQLiteConnection</param>
        /// <param name="list">data</param>
        public static void SaveTable<T>(SQLiteConnection connection, List<T> list)
        {
            connection.DropTable<T>();
            connection.CreateTable<T>();
            connection.InsertAll(list);
        }
        /// <summary>
        /// Get data from SQLite Connection
        /// </summary>
        /// <typeparam name="T">Class Name</typeparam>
        /// <param name="connection">SQLiteConnection</param>
        /// <returns>List</returns>
        public static List<T> Get<T>(SQLiteConnection connection) where T : new()
        {
            List<T> ret = new List<T>();
            if (IsTableExists<T>(connection))
            {
                var table = connection.Table<T>();
                if (table.Count() > 0)
                {
                    return table.ToList<T>();
                }
            }
            return ret;
        }
    }
}
