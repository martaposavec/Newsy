namespace Newsy.ViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PublishedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
