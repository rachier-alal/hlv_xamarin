using Firebase.Database;
using Hublov.Models;
using Hublov.ViewModels.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hublov.EventListeners
{
    public class HubsListener 
    {
        public string account = DependencyService.Get<IFirebaseAuthenticator>().UserDetails();
        FirebaseClient firebase = new FirebaseClient("https://hubforms-a8b20-default-rtdb.europe-west1.firebasedatabase.app/");
        public async Task<List<Hubs>> GetAllPersons()
        {
            return (await firebase
              .Child("Profiles")
              .OnceAsync<Hubs>()).Select(item => new Hubs
              {
                  Name = item.Object.Name,
                  Profession = item.Object.Profession,
                  Gender = item.Object.Gender,
                  Bio = item.Object.Bio,
                  Birth = item.Object.Birth,
                  UserID = item.Object.UserID
              }).ToList();
        }

      
    }
}
