using System.Threading.Tasks;
using Hublov.ViewModels.Auth;
using Firebase.Auth;
using Xamarin.Forms;
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

        bool IFirebaseAuthenticator.IsUserLoggedIn()
        {
            if (FirebaseAuth.Instance.CurrentUser != null)
            {
                return true;
            }
            return false;
        }


        string IFirebaseAuthenticator.UserDetails()
        {
            var user = FirebaseAuth.Instance.CurrentUser.Uid;
            return user;
        }
    }
}