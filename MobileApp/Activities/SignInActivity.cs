using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using MobileApp.Models;
using System;

namespace MobileApp.Activities
{

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    class SignInActivity : AppCompatActivity
    {
        private Database db;

        private EditText editTextIdIn;
        private EditText editTextPassIn;
        private Button sendSignIn;

        private string toastText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.sign_in);

            db = new Database();
            db.CreateDatabase();

            editTextIdIn = FindViewById<EditText>(Resource.Id.editTextIdIn);
            editTextPassIn = FindViewById<EditText>(Resource.Id.editTextPassIn);

            sendSignIn = FindViewById<Button>(Resource.Id.sendSignIn);

            sendSignIn.Click += (sender, e) =>
            {
                if (editTextIdIn.Text.Equals("") || editTextPassIn.Text.Equals(""))
                {
                    toastText = "Por favor llene todos los espacios requeridos";
                }
                else if (!int.TryParse(editTextIdIn.Text, out int userIdNum))
                {
                    toastText = "Su cédula debe ser un número";
                }
                else
                {
                    Customer customer = db.GetCustomer(userIdNum);

                    if(customer == null)
                    {
                        toastText = "Este usuario no se encuentra registrado";
                    }
                    else
                    {
                        if (editTextPassIn.Text.Equals(customer.passcustomer))
                        {
                            toastText = "Sesión iniciada";
                            Intent intent = new Intent(this, typeof(FlightSearch));
                            OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
                            StartActivity(intent);
                            Finish();
                        }
                        else {
                            toastText = "Contraseña incorrecta";
                        }                   
                    }
                }
                Toast.MakeText(this, toastText, ToastLength.Short).Show();
            };
        }
    }
}