using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Hublov.ViewModels.Auth;
using Firebase.Auth;
using Org.Apache.Http.Authentication;
using Xamarin.Forms;
using Hublov.Droid.Implementations;
using Android.Gms.Extensions;

[assembly: Dependency(typeof(Hublov.Droid.Implementations.FirebaseAuthenticator))]
namespace Hublov.Droid.Implementations
{
    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        /// <summary>
        /// Login into firebase 
        /// </summary>
        /// <param name="email"> user email </param>
        /// <param name="password">user password</param>
        /// <returns></returns>
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            var user = await MainActivity.Auth.SignInWithEmailAndPasswordAsync(email, password);
            var token = await FirebaseAuth.Instance.CurrentUser.GetIdToken(false).AsAsync<GetTokenResult>();

            return token.Token;
        }


        /// <summary>
        /// Signup to app firebase 
        /// </summary>
        /// <param name="email">user email</param>
        /// <param name="password">user password</param>
        /// <returns></returns>
        public async Task<string> SignupWithEmailPassword(string email, string password)
        {
            var user = await MainActivity.Auth.CreateUserWithEmailAndPasswordAsync(email, password);
            var token = await FirebaseAuth.Instance.CurrentUser.GetIdToken(false).AsAsync<GetTokenResult>();
            return token.Token;
        }
    }
}