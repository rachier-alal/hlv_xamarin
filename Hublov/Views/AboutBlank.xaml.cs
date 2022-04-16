using System;
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

        private void Save_Clicked(object sender, EventArgs e)
        {
            try
            {
                DateTime dob = DOB.Date;
                TimeSpan diff = DateTime.Now - dob;
            }catch(Exception ex)
            {
                TimeSpan diff = DateTime.Now - DateTime.Now;
            }
            
            
            if (Names.Text != "" && occupation.Text != "" && Bio.Text!= "" && Gender.Items[Gender.SelectedIndex] != "")
            {
                firebaseClient.Child("Statuses").PostAsync(new Hubs
                {
                    Name = Names.Text,
                    Profession = occupation.Text,
                    Gender = Gender.Items[Gender.SelectedIndex],
                    Bio = Bio.Text,
                    Birth = DOB.Date,
                    UserID = DependencyService.Get<IFirebaseAuthenticator>().UserDetails()

                });
            }
        }
        
    }
}