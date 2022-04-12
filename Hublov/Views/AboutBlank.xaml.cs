using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Hublov.Models;
using Hublov.ViewModels.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hublov.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutBlank : ContentPage
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://hubforms-a8b20-default-rtdb.europe-west1.firebasedatabase.app/");

        public AboutBlank()
        {
            InitializeComponent();
            Title = "Profile Details";
        }
        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    if (status.Text != "")
        //    {
        //        firebaseClient.Child("Statuses").PostAsync(new MyDatabaseRecord
        //        {
        //            StatusText = status.Text,
        //            UserID = DependencyService.Get<IFirebaseAuthenticator>().UserDetails()

        //        });
        //    }
        //    status.Text = "";
        //}
    }
}