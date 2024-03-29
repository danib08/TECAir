﻿using SQLite;
using MobileApp.Models;
using System.Collections.Generic;
using Android.Util;
using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;

namespace MobileApp
{
    internal class Database
    {
        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        private static readonly HttpClient client = new HttpClient();
        private const string Ipv4 = "192.168.0.10";
        private readonly string baseAddress = "http://" + Ipv4 + ":80/api/";

        public bool CreateDatabase()
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                connection.CreateTable<Worker>();
                connection.CreateTable<Customer>();
                connection.CreateTable<Plane>();
                connection.CreateTable<Flight>();
                connection.CreateTable<Bag>();
                connection.CreateTable<CustomerInFlight>();
                connection.CreateTable<CustomerLocal>(); // SQLite-only table
                connection.CreateTable<CustomerInFlightLocal>(); // SQLite-only table
                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        // PostgreSQL Synchronization 
        public async Task SyncAsync()
        {
            client.BaseAddress = new Uri(baseAddress);
            await SyncCustomersAsync();
            await SyncBagsAsync();
            await SyncPlanesAsync();
            await SyncFlightsAsync();
            await SyncWorkersAsync();
            await SyncCustomersInFlightsAsync();
        }

        private async Task SyncCustomersAsync()
        {
            string url = "Customers";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string response = await client.GetStringAsync(url);

            List<Customer> serverList = JsonConvert.DeserializeObject<List<Customer>>(response);
            List<Customer> newList = serverList;  // Copy server data to local app data

            List<CustomerLocal> localList = GetLocalCustomers();
            foreach (CustomerLocal item in localList)
            {
                newList.Add(item);

                // Post to server
                string json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                await client.PostAsync(url, content);
            }

            // Clear all data in Customer Table
            using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
            connection.Query<Customer>("DELETE FROM Customer");
            connection.Query<CustomerLocal>("DELETE FROM CustomerLocal");
            
            // Add updated data to app database
            foreach (Customer c in newList)
            {
                connection.Insert(c);
            }
        }

        private async Task SyncBagsAsync()
        {
            string url = "Bags";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string response = await client.GetStringAsync(url);

            List<Bag> serverList = JsonConvert.DeserializeObject<List<Bag>>(response);
          
            // Clear all data in Bag Table
            using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
            connection.Query<Bag>("DELETE FROM Bag");

            // Add updated data to app database
            foreach (Bag bag in serverList)
            {
                connection.Insert(bag);
            }
        }

        private async Task SyncPlanesAsync()
        {
            string url = "Planes";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string response = await client.GetStringAsync(url);

            List<Plane> serverList = JsonConvert.DeserializeObject<List<Plane>>(response);

            // Clear all data in Plane Table
            using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
            connection.Query<Plane>("DELETE FROM Plane");

            // Add updated data to app database
            foreach (Plane plane in serverList)
            {
                connection.Insert(plane);
            }
        }

        private async Task SyncWorkersAsync()
        {
            string url = "Workers";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string response = await client.GetStringAsync(url);

            List<Worker> serverList = JsonConvert.DeserializeObject<List<Worker>>(response);

            // Clear all data in Worker Table
            using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
            connection.Query<Worker>("DELETE FROM Worker");

            // Add updated data to app database
            foreach (Worker worker in serverList)
            {
                connection.Insert(worker);
            }
        }

        private async Task SyncFlightsAsync()
        {
            string url = "Flights";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string response = await client.GetStringAsync(url);

            List<Flight> serverList = JsonConvert.DeserializeObject<List<Flight>>(response);

            // Clear all data in Flight Table
            using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
            connection.Query<Plane>("DELETE FROM Flight");

            // Add updated data to app database
            foreach (Flight flight in serverList)
            {
                connection.Insert(flight);
            }
        }

        private async Task SyncCustomersInFlightsAsync()
        {
            string url = "CustomersInFlights";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string response = await client.GetStringAsync(url);

            List<CustomerInFlight> serverList = JsonConvert.DeserializeObject<List<CustomerInFlight>>(response);
            List<CustomerInFlight> newList = serverList;  // Copy server data to local app data

            List<CustomerInFlightLocal> localList = GetLocalCustomersInFlights();
            foreach (CustomerInFlightLocal item in localList)
            {
                newList.Add(item);

                // Post to server
                string json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                await client.PostAsync(url, content);
            }

            // Clear all data in CustomerInFlight Table
            using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
            connection.Query<Customer>("DELETE FROM CustomerInFlight");
            connection.Query<CustomerLocal>("DELETE FROM CustomerInFlight");

            // Add updated data to app database
            foreach (CustomerInFlight c in newList)
            {
                connection.Insert(c);
            }
        }

        public List<Flight> SearchFlights(string Origin, string Destination)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                var tmpList = connection.Table<Flight>().ToList();

                List<Flight> flightsSearched = new List<Flight>();

                foreach (Flight f in tmpList)
                {
                    string[] subsOrigin = f.Origin.Split("/");
                    string[] subsDest = f.Destination.Split("/");

                    if ((subsOrigin[0].Equals(Origin) || subsOrigin[1].Equals(Origin)) && 
                        (subsDest[0].Equals(Destination) || subsDest[1].Equals(Destination)))
                    {
                        flightsSearched.Add(f);
                    }
                }
                return flightsSearched;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        // Post Methods
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

        public bool InsertFlight(Flight flight)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                connection.Insert(flight);

                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool InsertPlane(Plane plane)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                connection.Insert(plane);
                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool InsertBag(Bag bag)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                connection.Insert(bag);
                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public bool InsertCustomerInFlight(CustomerInFlight cif)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                connection.Insert(cif);
                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool InsertCustomerLocal(CustomerLocal customer)
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

        public bool InsertCustomerInFlightLocal(CustomerInFlightLocal cif)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                connection.Insert(cif);
                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        // Multi-Value Get Methods
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

        public List<Flight> GetFlights()
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                return connection.Table<Flight>().ToList();
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }
 
        public List<Plane> GetPlanes()
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                return connection.Table<Plane>().ToList();
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }
        public List<Bag> GetBags()
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                return connection.Table<Bag>().ToList();
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public List<CustomerInFlight> GetCustomersInFlights()
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                return connection.Table<CustomerInFlight>().ToList();
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public List<CustomerLocal> GetLocalCustomers()
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                return connection.Table<CustomerLocal>().ToList();
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }
        public List<CustomerInFlightLocal> GetLocalCustomersInFlights()
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                return connection.Table<CustomerInFlightLocal>().ToList();
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        // Single-Value Get Methods
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
        public Flight GetFlight(string flightId)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                List<Flight> flights = connection.Query<Flight>("SELECT * FROM Flight Where Flightid=?", flightId);
                return flights.Find(flight => flight.Flightid.Equals(flightId)); ;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public Plane GetPlane(string planeId)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                List<Plane> planes = connection.Query<Plane>("SELECT * FROM Plane Where Planeid=?", planeId);
                return planes.Find(plane => plane.Planeid.Equals(planeId)); ;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public Bag GetBag(string bagId)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                List<Bag> bags = connection.Query<Bag>("SELECT * FROM Bag Where Bagid=?", bagId);
                return bags.Find(bag => bag.Bagid.Equals(bagId)); ;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public CustomerInFlight GetCustomerInFlight(int customerId, string flightId) 
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                List<CustomerInFlight> cifs = connection.Query<CustomerInFlight>("SELECT * FROM CustomerInFlight Where" +
                    " Customerid=? And Flightid=?", customerId, flightId);
                return cifs.Find(cif => cif.Customerid == customerId && cif.Flightid.Equals(flightId));
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        // Put/Update Methods
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
                connection.Query<Customer>("UPDATE Customer set namecustomer=?,lastnamecustomer?=,passcustomer=?,email=?,phone=?,studentid=?,university=?" +
                    " Where Customerid=?", customer.namecustomer, customer.lastnamecustomer, customer.passcustomer, customer.Customerid, customer.email, customer.phone, customer.studentid, customer.university);
                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool UpdateFlight(Flight flight)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                connection.Query<Flight>("UPDATE Flight set Bagquantity=?,Userquantity?=,Gate=?,Departure=?,Arrival=?,Origin=?,Destination=?," +
                    "Status=?,Price=?,Discount=?,Planeid=?,Workerid=?" +
                    " Where Flightid=?", flight.Bagquantity, flight.Userquantity, flight.Gate, flight.Departure, flight.Arrival, flight.Origin, 
                    flight.Destination, flight.Status, flight.Price, flight.Discount, flight.Planeid, flight.Workerid);
                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool UpdatePlane(Plane plane)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                connection.Query<Plane>("UPDATE Plane set Model=?,Passangercap?=,Bagcap=?" +
                    " Where Planeid=?", plane.Model, plane.Passangercap, plane.Bagcap);
                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool UpdateBag(Bag bag)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                connection.Query<Bag>("UPDATE Bag set Weight=?,Color?=,Price=?,Customerid=?,Flightid=?" +
                    " Where Bagid=?", bag.Weight, bag.Color, bag.Price, bag.Customerid, bag.Flightid);
                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public bool UpdateCustomerInFlight(CustomerInFlight cif)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                connection.Query<Bag>("UPDATE CustomerInFlight set CustomerId=?,Flightid=? Where Seatnum=?", 
                    cif.Customerid, cif.Flightid, cif.Seatnum);
                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        // Delete Methods
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

        public bool DeleteFlight(Flight flight)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                connection.Delete(flight);
                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool DeletePlane(Plane plane)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                connection.Delete(plane);
                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool DeleteBag(Bag bag)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                connection.Delete(bag);
                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool DeleteCustomerInFlight(CustomerInFlight cif)
        {
            try
            {
                using var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "TecAir.db"));
                connection.Delete(cif);
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