using Newsy.ViewModels;

namespace Newsy.Services.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Authenticate given username and password - login user
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Token</returns>
        string Authenticate(string username, string password);

        /// <summary>
        /// Create new user - signup user
        /// </summary>
        /// <param name="model">User data</param>
        void Signup(SignupViewModel model);
    }

}
