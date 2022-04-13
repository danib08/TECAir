using Android.App;
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
using AndroidX.AppCompat.App;

namespace MobileApp
{
    class SignUpActivity : AppCompatActivity
    {

        private Database db;

        private EditText editTextId;
        private EditText editTextPass;
        private EditText editTextName;
        private EditText editTextLastName;
        private EditText editTextEmail;
        private EditText editTextPhone;
        private EditText editTextStudentId;
        private EditText editTextUni;

        private Button sendSignUp;

        private String toastText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.sign_up);

            db = new Database();
            db.CreateDatabase();

            editTextId = FindViewById<EditText>(Resource.Id.editTextId);
            editTextPass = FindViewById<EditText>(Resource.Id.editTextPass);
            editTextName = FindViewById<EditText>(Resource.Id.editTextName);
            editTextLastName = FindViewById<EditText>(Resource.Id.editTextLastName);
            editTextEmail = FindViewById<EditText>(Resource.Id.editTextEmail);
            editTextPhone = FindViewById<EditText>(Resource.Id.editTextPhone);
            editTextStudentId = FindViewById<EditText>(Resource.Id.editTextStudentId);
            editTextUni = FindViewById<EditText>(Resource.Id.editTextUni);

            sendSignUp = FindViewById<Button>(Resource.Id.sendSignUp);

            sendSignUp.Click += (sender, e) =>
            {
                if (editTextId.Text.Equals("") || editTextPass.Text.Equals("") || editTextName.Text.Equals("") || editTextLastName.Text.Equals("") || editTextEmail.Text.Equals("") ||
                    editTextPhone.Text.Equals(""))
                {
                    toastText = "Por favor llene todos los espacios requeridos";
                }
                else if(!int.TryParse(editTextId.Text, out int userIdNum))
                {
                    toastText = "Su cédula debe ser un número";
                }
                else if (!int.TryParse(editTextStudentId.Text, out int userPhone))
                {
                    toastText = "Su número telefónico debe ser un número";
                }
                else if(!editTextStudentId.Equals("") && !int.TryParse(editTextStudentId.Text, out int studentIdNum))
                {
                    toastText = "Su carné de estudiante debe ser un número";
                }
                else
                {
                    Customer customer = new Customer
                    {
                        Customerid = userIdNum,
                        Namecustomer = editTextName.Text,
                        Lastnamecustomer = editTextLastName.Text,
                        Passcustomer = editTextPass.Text,
                        Email = editTextEmail.Text,
                        Phone = userPhone,
                        Studentid = Int32.Parse(editTextStudentId.Text),
                        University = editTextUni.Text
                    
                    };

                    if (db.InsertCustomer(customer))
                    {
                        toastText = "SI SE PUDO";
                        Finish();
                    }
                    else
                    {
                        toastText = "cagaste";
                    }
                }

                Toast.MakeText(this, toastText, ToastLength.Short).Show();

            };
        }
    }
}