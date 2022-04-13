using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileApp.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    class BusquedaVuelos : AppCompatActivity
    {

        private Database db;

        private EditText editTextOrigin;
        private EditText editTextDestination;

        private Button sendBusqueda;

        private String toastText;

        private List<Flight> listFlights;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.vuelos);

            db = new Database();
            db.CreateDatabase();

            Plane plane1 = new Plane
            {
                Planeid = "AXJ720",
                Model = "Boeing777",
                Passangercap = 200,
                Bagcap = 250
            };

            Flight flight1 = new Flight
            {
                Flightid = "CM2012",
                Bagquantity = 0,
                Userquantity = 0,
                Gate = 2,
                Departure = "2022-08-22 16:40:00,",
                Arrival = "2022-08-24 13:15:00",
                Origin = "PTY",
                Destination = "INC",
                Stops = "",
                Status = "On Time",
                Price = 1000,
                Discount = 0,
                Planeid = "AXJ720",
                Workerid = 12345869

            };

            db.InsertPlane(plane1);
            db.DeleteFlight(flight1);

            editTextOrigin = FindViewById<EditText>(Resource.Id.editTextOrigin);
            editTextDestination = FindViewById<EditText>(Resource.Id.editTextDestination);

            sendBusqueda = FindViewById<Button>(Resource.Id.sendSignIn);

            sendBusqueda.Click += (sender, e) =>
            {
                if (editTextOrigin.Text.Equals("") || editTextDestination.Text.Equals(""))
                {
                    toastText = "Por favor llene todos los espacios solicitados";
                }
                else
                {
                   List<Flight> vuelito = db.SearchFlights(editTextOrigin.Text, editTextDestination.Text);
                   // vuelito.Find(worker => worker.Workerid == workerId);
                    toastText = "Numero de vuelo: " + vuelito.First().Flightid; 
                }

                Toast.MakeText(this, toastText, ToastLength.Short).Show();

            };
        }

    }
}