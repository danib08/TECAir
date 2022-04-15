using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileApp.Activities
{
    class BusquedaVuelos : AppCompatActivity
    {

        private Database db;

        private EditText editTextOrigen;
        private EditText editTextDestino;

        private Button sendBusqueda;

        private String toastText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.vuelos);


            editTextOrigen = FindViewById<EditText>(Resource.Id.editTextOrigen);
            editTextDestino = FindViewById<EditText>(Resource.Id.editTextDestino);

            sendBusqueda = FindViewById<Button>(Resource.Id.sendSignIn);

            sendBusqueda.Click += (sender, e) =>
            {
                if (editTextOrigen.Text.Equals("") || editTextDestino.Text.Equals(""))
                {
                    toastText = "Por favor llene todos los espacios solicitados";
                }
                else
                {
                    
                }

                Toast.MakeText(this, toastText, ToastLength.Short).Show();

            };
        }

    }
}