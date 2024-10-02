using Newsy.Models;
using Newsy.ViewModels;

namespace Newsy.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel MapToViewModel(this User user)
        {
            var viewModel = new UserViewModel()
            {
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                Username = user.Username,
                FullName = user.FullName
            };

            return viewModel;
        }

        public static List<UserViewModel> MapToViewModelList(this List<User> Users) {
            return Users.Select(x => x.MapToViewModel()).ToList();
        }
    }
}
