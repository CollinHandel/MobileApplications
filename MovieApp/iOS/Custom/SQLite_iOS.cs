using System;
using System.IO;
using MovieApp.Custom;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(MovieApp.iOS.Custom.SQLite_iOS))]
namespace MovieApp.iOS.Custom
{
    public class SQLite_iOS:ISQLite
    {
        public SQLite_iOS()
        {
        }

        public SQLiteConnection GetConnection()
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentPath, "..", "Library");
            var dbPath = Path.Combine(libraryPath, "myDatabase.db3");

            return new SQLiteConnection(new SQLitePlatformIOS(), dbPath);
        }
    }
}
