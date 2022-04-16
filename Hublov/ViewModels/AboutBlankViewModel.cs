using System;
using Firebase.Database;
using Firebase.Database.Query;
using Hublov.Models;
using Hublov.ViewModels.Auth;
using Xamarin.Forms;
using System.Windows.Input;


namespace Hublov.ViewModels
{ 
    public class AboutBlankViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand Save_Clicked { get; set; }
        public string Names
        {
            get { return Names; }
            set
            {
                if (Names == value)
                    return;

                Names = value;
                OnPropertyChanged();
            }
        }
        public string occupation { get; set; }
        public string Gender { get; set; }
        public string Bio { get; set; }
        public DateTime Birth { get; set; }



        FirebaseClient firebaseClient = new FirebaseClient("https://hubforms-a8b20-default-rtdb.europe-west1.firebasedatabase.app/");
        public AboutBlankViewModel(INavigation navigation)
        {
            this.Title = "My Profile";
            this.Navigation = navigation;
            PageService = new PageService();
            Save_Clicked = new Command(ONSave_Clicked);
        }
        private void ONSave_Clicked()
        {
            try
            {
                DateTime dob =Birth;
                TimeSpan diff = DateTime.Now - dob;
            }
            catch (Exception ex)
            {
                TimeSpan diff = DateTime.Now - DateTime.Now;
            }


            if (Names != "" && occupation != "" && Bio != "" && Gender != "")
            {
                firebaseClient.Child("Statuses").PostAsync(new Hubs
                {
                    Name = Names,
                    Profession = occupation,
                    Gender = Gender,
                    Bio = Bio,
                    Birth = Birth,
                    UserID = DependencyService.Get<IFirebaseAuthenticator>().UserDetails()

                });
            }
            
        }
    }
   
}
