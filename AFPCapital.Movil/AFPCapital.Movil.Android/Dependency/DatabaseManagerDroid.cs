using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AFPCapital.Movil.Dependency;
using SQLite;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(AFPCapital.Movil.Droid.Dependency.DatabaseManagerDroid))]
namespace AFPCapital.Movil.Droid.Dependency
{
    public class DatabaseManagerDroid : IStorageManager
    {
        public DatabaseManagerDroid()
        {

        }

        public SQLiteConnection GetConnection()
        {
            SQLitePCL.Batteries.Init();
            var sqliteFilename = "AfpCapital.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
    
}