using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using MobileApp.Models;
using System.Collections.Generic;

namespace MobileApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private EditText textId;
        private EditText textName;
        private EditText textLast;
        private EditText textPass;
        private Button _postButton;
        private Button _deleteButton;
        private Button _updateButton;
        private ListView listData;
        private List<Worker> listWorkers;
        private Database db;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.pruebita);

            db = new Database();
            db.CreateDatabase();

            listData = FindViewById<ListView>(Resource.Id.listView1);

            textId = FindViewById<EditText>(Resource.Id.cedula);
            textName = FindViewById<EditText>(Resource.Id.nombre);
            textLast = FindViewById<EditText>(Resource.Id.apellido);
            textPass = FindViewById<EditText>(Resource.Id.contra);

            _postButton = FindViewById<Button>(Resource.Id.post);
            _deleteButton = FindViewById<Button>(Resource.Id.delete);
            _updateButton = FindViewById<Button>(Resource.Id.update);

            listWorkers = new List<Worker>();

            LoadData();

            _postButton.Click += delegate
            {
                bool isIdNum = int.TryParse(textId.Text, out int userIdNum);

                Worker worker = new Worker
                {
                    Workerid = userIdNum,
                    Nameworker = textName.Text,
                    Lastnameworker = textLast.Text,
                    Passworker = textPass.Text
                };

                db.InsertWorker(worker);
                LoadData();
            };

            _updateButton.Click += delegate
            {
                bool isIdNum = int.TryParse(textId.Text, out int userIdNum);

                Worker worker = new Worker
                {
                    Workerid = userIdNum,
                    Nameworker = textName.Text,
                    Lastnameworker = textLast.Text,
                    Passworker = textPass.Text
                };

                db.UpdateWorker(worker);
                LoadData();
            };

            _deleteButton.Click += delegate
            {
                bool isIdNum = int.TryParse(textId.Text, out int userIdNum);

                Worker worker = new Worker
                {
                    Workerid = userIdNum,
                    Nameworker = textName.Text,
                    Lastnameworker = textLast.Text,
                    Passworker = textPass.Text
                };

                db.DeleteWorker(worker);
                LoadData();
            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void LoadData()
        {
            listWorkers = db.GetWorkers();
            var adapter = new ListViewAdapter(this, listWorkers);

            listData.Adapter = adapter;
        }
    }
}