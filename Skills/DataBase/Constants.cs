using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Skills.DataBase
{
    public  class Constants
    {
        public const string DatabaseFilename = "skills.db3";
        public const string BaseURL = "https://jsonplaceholder.typicode.com/posts";

        public const SQLite.SQLiteOpenFlags Flags =
        SQLite.SQLiteOpenFlags.ReadWrite |
        SQLite.SQLiteOpenFlags.Create |
        SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
