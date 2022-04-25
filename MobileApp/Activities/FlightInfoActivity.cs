using Android.App;
using AndroidX.AppCompat.App;
using Android.Content;
using Android.OS;
using MobileApp.Models;
using Android.Widget;

namespace MobileApp.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    class FlightInfoActivity : AppCompatActivity
    {
        private Database db;

        private TextView textId;
        private TextView textOrigin;
        private TextView textDestination;
        private TextView textDeparture;
        private TextView textArrival;
        private TextView textGate;
        private TextView textPrice;
        private Button buyButton;
        private int loggedId;
        private string flightIdClass;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.flight_info);

            db = new Database();
            db.CreateDatabase();

            string flightId = Intent.GetStringExtra("flightId");
            int customerId = Intent.GetIntExtra("customerId", 0);
            flightIdClass = flightId;
            Flight flight = db.GetFlight(flightId);
            loggedId = customerId;

            textId = FindViewById<TextView>(Resource.Id.title);
            textOrigin = FindViewById<TextView>(Resource.Id.textOrigin);
            textDestination = FindViewById<TextView>(Resource.Id.textDestin);
            textDeparture = FindViewById<TextView>(Resource.Id.textDeparture);
            textArrival = FindViewById<TextView>(Resource.Id.textArrival);
            textGate = FindViewById<TextView>(Resource.Id.textGate);
            textPrice = FindViewById<TextView>(Resource.Id.textPrice);
            buyButton = FindViewById<Button>(Resource.Id.buyBtn);

            textId.Text = "Vuelo #" + flight.Flightid;
            textOrigin.Text = flight.Origin;
            textDestination.Text = flight.Destination;
            textDeparture.Text = flight.Departure;
            textArrival.Text = flight.Arrival;
            textGate.Text = flight.Gate.ToString();
            textPrice.Text = flight.Price.ToString();

            buyButton.Click += (sender, e) =>
            {
                Intent intent = new Intent(this, typeof(BuyActivity));
                intent.PutExtra("flightId", flightIdClass);
                intent.PutExtra("customerId", loggedId);
                OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
                StartActivity(intent);
            };
        }
    }
}