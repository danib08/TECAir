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
                connection.CreateTable<Customer>();
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

        public bool InsertCustomer(Customer customer)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                connection.Insert(customer);
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

        public List<Customer> GetCustomers()
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                return connection.Table<Customer>().ToList();
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }


        public Worker GetWorker(int workerId)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                List<Worker> workers = connection.Query<Worker>("SELECT * FROM Worker Where Workerid=?", workerId);
                return workers.Find(worker => worker.Workerid == workerId);

            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }

        }

        public Customer GetCustomer(int customerId)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                List<Customer> customers = connection.Query<Customer>("SELECT * FROM Customer Where Customerid=?", customerId);
                return customers.Find(customer => customer.Customerid == customerId); ;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
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

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                connection.Query<Customer>("UPDATE Customer set Namecustomer=?,Lastnamecustomer?=,Passcustomer=?,Email=?,Phone=?,Studentid=?,University=?" +
                    " Where Customerid=?", customer.Namecustomer, customer.Lastnamecustomer, customer.Passcustomer, customer.Customerid, customer.Email, customer.Phone, customer.Studentid, customer.University);
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

        public bool DeleteCustomer(Customer customer)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                connection.Delete(customer);
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