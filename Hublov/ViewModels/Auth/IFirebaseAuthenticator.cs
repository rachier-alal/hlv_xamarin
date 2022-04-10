using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hublov.ViewModels.Auth
{
    public interface IFirebaseAuthenticator
    {
        Task<string> LoginWithEmailPassword(string email, string password);
        Task<string> SignupWithEmailPassword(string email, string password);
        bool IsUserLoggedIn();
        string UserDetails();
    }

}
