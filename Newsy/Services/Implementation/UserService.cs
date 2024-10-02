using Newsy.Mappers;
using Newsy.Repository.Interfaces;
using Newsy.Services.Interfaces;
using Newsy.ViewModels;

namespace Newsy.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserViewModel> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return users.MapToViewModelList();
        }

        public UserViewModel GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            return user.MapToViewModel();
        }
    }
}
