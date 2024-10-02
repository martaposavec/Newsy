namespace Newsy.Models
{
    public class User
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public required string Username { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Password hash
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Full name
        /// </summary>
        public string FullName { 
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            } 
        }
    }
}
