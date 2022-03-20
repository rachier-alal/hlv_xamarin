using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Firebase.Firestore;
using Firebase;
using Firebase.Auth;

namespace Hublov.Droid
{
    [Activity(Label = "Hublov", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static FirebaseApp app;
        public static FirebaseAuth Auth;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            InitFirebaseAuth();
            LoadApplication(new App());
        }
        private void InitFirebaseAuth()
        {
            var options = new FirebaseOptions.Builder()
                .SetProjectId("hubforms-a8b20").SetApplicationId("1:711693219316:android:a959a3a436d6bf4500b5a1")
                .SetApiKey("89:1f:ff:70:bf:02:9c:51:49:d4:b8:e4:6c:52:b8:b4:da:b2:d5:a7")
                .SetDatabaseUrl("xxxxxxx")
                .SetStorageBucket("xxxxxxxx").Build();
            if (app == null)
                app = FirebaseApp.InitializeApp(this, options);
            Auth = FirebaseAuth.GetInstance(app);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}