using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using App2.Droid;
using App2.Droid.Persistence;
using App2.Persistence;

[assembly: Dependency(typeof(SQLiteDb))]
namespace App2.Droid.Persistence
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}