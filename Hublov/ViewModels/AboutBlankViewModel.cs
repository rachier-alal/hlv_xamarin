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
        private string _names;
        private string _gender;
        private string _occupation;
        private DateTime _dob;
        private string _bio;
        public string Names
        {
            get { return _names; }
            set
            {
                if (_names == value)
                    return;

                _names = value;
                OnPropertyChanged();
            }
        }
        public string Occupation
        {
            get { return _occupation; }
            set
            {
                if (_occupation == value)
                    return;

                _occupation = value;
                OnPropertyChanged();
            }
        }
        public string Gender
        {
            get { return _gender; }
            set
            {
                if (_gender == value)
                    return;

                _gender = value;
                OnPropertyChanged();
            }
        }
        public string Bio
        {
            get { return _bio; }
            set
            {
                if (_bio == value)
                    return;

                _bio = value;
                OnPropertyChanged();
            }
        }
        public DateTime Birth {
            get { return _dob; }
            set
            {
                if (_dob == value)
                    return;

                _dob = value;
                OnPropertyChanged();
            }
        }




        public AboutBlankViewModel(INavigation navigation)
        {
            this.Title = "Profile";
            this.Navigation = navigation;
            PageService = new PageService();
            this.Save_Clicked = new Command(ONSave_Clicked);
        }
        FirebaseClient firebaseClient = new FirebaseClient("https://hubforms-a8b20-default-rtdb.europe-west1.firebasedatabase.app/");
        private void ONSave_Clicked()
        {
            try
            {
                DateTime dob = Birth;
                TimeSpan diff = DateTime.Now - dob;
            }
            catch (Exception ex)
            {
                TimeSpan diff = DateTime.Now - DateTime.Now;
            }


            if (Names != "" && Occupation != "" && Bio != "" && Gender != "")
            {
                firebaseClient.Child("Statuses").PostAsync(new Hubs
                {
                    Name = Names,
                    Profession = Occupation,
                    Gender = Gender,
                    Bio = Bio,
                    Birth = Birth,
                    UserID = DependencyService.Get<IFirebaseAuthenticator>().UserDetails()

                });
            }

        }
    }
   
}
