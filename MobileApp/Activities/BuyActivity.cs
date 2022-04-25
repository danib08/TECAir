using Android.App;
using AndroidX.AppCompat.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobileApp.Models;

namespace MobileApp.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    class BuyActivity : AppCompatActivity
    {
        private Database db;
        private string flightId;
        private int customerId;

        private Button payButton;
        private EditText textCardName;
        private EditText textCardNum;
        private EditText textCCV;
        private EditText textExpires;
        private string toastText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.payment);

            db = new Database();
            db.CreateDatabase();

            string flightIdTmp = Intent.GetStringExtra("flightId");
            int customerIdTmp = Intent.GetIntExtra("customerId", 0);

            flightId = flightIdTmp;
            customerId = customerIdTmp;

            payButton = FindViewById<Button>(Resource.Id.btnPayment);
            textCardName = FindViewById<EditText>(Resource.Id.textCardName);
            textCardNum = FindViewById<EditText>(Resource.Id.textNumCard);
            textCCV = FindViewById<EditText>(Resource.Id.textCCV);
            textExpires = FindViewById<EditText>(Resource.Id.textDate);


            payButton.Click += (sender, e) =>
            {
                if (textCardName.Text.Equals("") || textCardNum.Text.Equals("") || textCCV.Text.Equals("") ||
                textExpires.Text.Equals(""))
                {
                    toastText = "Por favor rellene toda la información solicitada.";
                }
                else
                {
                    CustomerInFlight cif = new CustomerInFlight
                    {
                        Seatnum = 0,
                        Customerid = customerId,
                        Flightid = flightId
                    };

                    if (db.InsertCustomerInFlight(cif))
                    {
                        // Local Table
                        CustomerInFlightLocal customerLocal = new CustomerInFlightLocal
                        {
                            Seatnum = 0,
                            Customerid = customerId,
                            Flightid = flightId
                        };
                        db.InsertCustomerInFlightLocal(customerLocal);
                        toastText = "Pago realizado exitosamente.";
                        Finish();
                    }
                    else
                    {
                        toastText = "Usted ya compró un asiento en este vuelo.";
                    }
                }

                Toast.MakeText(this, toastText, ToastLength.Short);
            };

        }
    }
}