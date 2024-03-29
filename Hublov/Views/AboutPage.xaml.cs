﻿using System;
using Firebase.Database.Query;
using Xamarin.Forms;
using Firebase.Database;
using Hublov.Models;
using Hublov.ViewModels.Auth;

namespace Hublov.Views
{
    public partial class AboutPage : ContentPage 
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://hubforms-a8b20-default-rtdb.europe-west1.firebasedatabase.app/");
        public AboutPage()
        {
            InitializeComponent();
            //BindingContext = new AboutViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(status.Text != "") {
                firebaseClient.Child("Statuses").PostAsync(new MyDatabaseRecord
                {
                    StatusText = status.Text,
                    UserID = DependencyService.Get<IFirebaseAuthenticator>().UserDetails()

                }) ;
            }
            status.Text = "";
        }
       
    }
}