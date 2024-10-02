using Newsy.Models;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

namespace Newsy.Data
{
    public static class MockData
    {
        private static readonly PasswordHasher<User> _passwordHasher;

        static MockData()
        {
            _passwordHasher = new PasswordHasher<User>();
        }

        public static List<User> MockUsers()
        {
            var user1 = new User()
            {
                Id = 1,
                Username = "author1",
                FirstName = "Marko",
                LastName = "Markić",
            };

            var user2 = new User()
            {
                Id = 2,
                Username = "author2",
                FirstName = "Ana",
                LastName = "Anić",
            };

            user1.PasswordHash = _passwordHasher.HashPassword(user1, "password1");
            user2.PasswordHash = _passwordHasher.HashPassword(user2, "password2");

            return new List<User> { user1, user2 };
        }

        public static List<Article> MockArticles()
        {
            var articles = new List<Article>()
            {
                new Article()
                {
                    Id = 1,
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Title = "Lorem ipsum",
                    PublishedOn = new DateTime(2024, 5, 25, 9, 21, 2),
                    ModifiedOn = new DateTime(2024, 5, 25, 9, 21, 2),
                    Author = MockUsers()[0]
                },
                new Article()
                {
                    Id = 2,
                    Content = "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean. A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth. Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic life One day however a small line of blind text by the name of Lorem Ipsum decided to leave for the far World of Grammar. The Big Oxmox advised her not to do so, because there were thousands of bad Commas, wild Question Marks and devious Semikoli, but the Little Blind Text didn’t listen. She packed her seven versalia, put her initial into the belt and made herself on the way. When she reached the first hills of the Italic Mountains, she had a last view back on the skyline of her hometown Bookmarksgrove, the headline of Alphabet Village and the subline of her own road, the Line Lane. Pityful a rethoric question ran over her cheek, then",
                    Title = "Far far away",
                    PublishedOn = new DateTime(2024, 9, 4, 15, 32, 12),
                    ModifiedOn = new DateTime(2024, 9, 4, 15, 32, 12),
                    Author = MockUsers()[1]
                }
            };

            return articles;
        }
    }
}
