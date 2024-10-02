using Newsy.Data;
using Newsy.Models;
using Newsy.Repository.Interfaces;

namespace Newsy.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private static List<User> _users;

        public UserRepository()
        {
            _users = MockData.MockUsers();
        }

        public void Save(User user)
        {
            var id = _users.Max(x => x.Id);
            user.Id = id;
            _users.Add(user);
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public User GetByUsername(string username)
        {
            return _users.FirstOrDefault(x => x.Username == username);
        }
    }
}
