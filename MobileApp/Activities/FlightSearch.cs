using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using MobileApp.Models;
using System.Collections.Generic;
using System.Linq;
using MobileApp.Adapters;

namespace MobileApp.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    class FlightSearch : AppCompatActivity
    {

        private Database db;

        private EditText editTextOrigin;
        private EditText editTextDestination;
        private Button searchBtn;
        private ListView listView;

        private string toastText;
        private List<Flight> listFlights;
        private FlightAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.flight_search);

            editTextOrigin = FindViewById<EditText>(Resource.Id.editTextOrigin);
            editTextDestination = FindViewById<EditText>(Resource.Id.editTextDestination);
            searchBtn = FindViewById<Button>(Resource.Id.sendSearch);
            listView = FindViewById<ListView>(Resource.Id.listView1);

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
                Origin = "PTY/Panama",
                Destination = "INC/Corea del Sur",
                Stops = "",
                Status = "On Time",
                Price = 1000,
                Discount = 0,
                Planeid = "AXJ720",
                Workerid = 12345869
            };

            db.InsertPlane(plane1);
            db.InsertFlight(flight1);
            
            searchBtn.Click += (sender, e) =>
            {
                if (editTextOrigin.Text.Equals("") || editTextDestination.Text.Equals(""))
                {
                    toastText = "Por favor llene todos los espacios solicitados";
                    Toast.MakeText(this, toastText, ToastLength.Short).Show();
                }
                else
                {                   
                    listFlights = db.SearchFlights(editTextOrigin.Text, editTextDestination.Text);

                    adapter = new FlightAdapter(this, listFlights);
                    listView.Adapter = adapter;

                    if (listFlights.Count == 0)
                    {
                        toastText = "No se encontraron vuelos coincidentes.";
                        Toast.MakeText(this, toastText, ToastLength.Short).Show();
                    } 
                    else {
                        editTextOrigin.Text = "";
                        editTextDestination.Text = "";
                    }
                }
            };
        }
    }
}