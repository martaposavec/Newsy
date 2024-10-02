using Newsy.ViewModels;

namespace Newsy.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of all existing users</returns>
        List<UserViewModel> GetAllUsers();

        /// <summary>
        /// Get user by ID
        /// </summary>
        /// <param name="id">ID of wanted user</param>
        /// <returns>User data</returns>
        UserViewModel GetUserById(int id);
    }
}
