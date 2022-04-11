using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

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
        //16:30

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.pruebita);

            textId = FindViewById<EditText>(Resource.Id.cedula);
            textName = FindViewById<EditText>(Resource.Id.nombre);
            textLast = FindViewById<EditText>(Resource.Id.apellido);
            textPass = FindViewById<EditText>(Resource.Id.contra);

            _postButton = FindViewById<Button>(Resource.Id.post);
            _deleteButton = FindViewById<Button>(Resource.Id.delete);
            _updateButton = FindViewById<Button>(Resource.Id.update);

            _postButton.Click += (sender, args) =>
            {
                
            };

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}