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
    class SignInActivity : AppCompatActivity
    {
        private Database db;

        private EditText editTextIdIn;
        private EditText editTextPassIn;

        private Button sendSignIn;

        private String toastText;

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
                        if (editTextPassIn.Text.Equals(customer.Passcustomer))
                        {
                            toastText = "Sesión iniciada";
                            Intent intent = new Intent(this, typeof(SignInActivity));
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