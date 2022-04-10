using System;
using Firebase.Database.Query;
using Firebase.Database;
using Hublov.Models;
using Hublov.Views;
using Xamarin.Forms;
using Hublov.ViewModels.Auth;

namespace Hublov.ViewModels
{
    public class AboutViewModel : BaseViewModel 
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://hubforms-a8b20-default-rtdb.europe-west1.firebasedatabase.app/");
        
        public AboutViewModel()
        {
            Title = "About";
        }
       
    }
}