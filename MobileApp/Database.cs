using SQLite;
using MobileApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Android.Util;

namespace MobileApp
{
    internal class Database
    {
        readonly string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool CreateDatabase()
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                connection.CreateTable<Worker>();
                return true;
            }
            catch(SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool InsertWorker(Worker worker)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                connection.Insert(worker);
                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public List<Worker> GetWorkers()
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                return connection.Table<Worker>().ToList();
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }
        public bool GetWorker(int workerId)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                connection.Query<Worker>("SELECT * FROM Worker Where Workerid=?", workerId);
                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }

        }

        public bool UpdateWorker(Worker worker)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                connection.Query<Worker>("UPDATE Worker set Nameworker=?,Lastnameworker?=,Passworker=?" +
                    " Where Workerid=?", worker.Nameworker, worker.Lastnameworker, worker.Passworker, worker.Workerid);
                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }

        }

        public bool DeleteWorker(Worker worker)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                connection.Delete(worker);
                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }

        }

    }
}