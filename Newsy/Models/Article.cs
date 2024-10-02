namespace Newsy.Models
{
    public class Article
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        public required string Content { get; set; }

        /// <summary>
        /// Date and time of publishing
        /// </summary>
        public DateTime PublishedOn { get; set; }

        /// <summary>
        /// Date and time of last modification
        /// </summary>
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// Author
        /// </summary>
        public required User Author { get; set; }
    }
}
