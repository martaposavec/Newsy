using Newsy.Models;

namespace Newsy.Repository.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of all existing users</returns>
        List<User> GetAll();

        /// <summary>
        /// Get user by ID
        /// </summary>
        /// <param name="id">ID of wanted user</param>
        /// <returns>User data</returns>
        User GetById(int id);

        /// <summary>
        /// Get user by username
        /// </summary>
        /// <param name="username">Username of wanted user</param>
        /// <returns>User data</returns>
        User GetByUsername(string username);

        /// <summary>
        /// Save new user
        /// </summary>
        /// <param name="user">User data to save</param>
        void Save(User user);    
    }
}
