using System;
using MovieApp.Models;
using SQLite.Net;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Custom
{
    public class Database
    {
        SQLiteConnection database;
        static object locker = new object();

        public Database()
        {
            // Get Connection string
            database = DependencyService.Get<ISQLite>().GetConnection();

            // Create database
            database.CreateTable<Movie>();
        }

        public void SaveMovie(Movie movie) {
            lock(locker) {
                database.Insert(movie);
            }
        }

        public List<Movie> GetMovies() {
            var Result = database.Query<Movie>("SELECT * FROM [Movie]");
            //var Result = { from db in database.Table<Movie>() select db };
            return Result;
        }
    }
}
