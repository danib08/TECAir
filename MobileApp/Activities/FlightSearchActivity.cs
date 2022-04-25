using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using MobileApp.Models;
using System.Collections.Generic;
using MobileApp.Adapters;
using Android.Content;

namespace MobileApp.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    class FlightSearchActivity : AppCompatActivity
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

                    listView.ItemClick += ListClick;
                }
            };
        }

        private void ListClick(object sender, AdapterView.ItemClickEventArgs eventArgs)
        {
            string clickedId = listFlights[eventArgs.Position].Flightid;

            Intent infoIntent = new Intent(this, typeof(FlightInfoActivity));
            infoIntent.PutExtra("flightId", clickedId);
            StartActivity(infoIntent);
            OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }
    }
}