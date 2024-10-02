using Newsy.Models;
using Newsy.ViewModels;

namespace Newsy.Mappers
{
    public static class ArticleMapper
    {
        public static ArticleViewModel MapToViewModel(this Article article)
        {
            var viewModel = new ArticleViewModel()
            {
                Author = article.Author.FullName,
                Content = article.Content,
                Id = article.Id,
                Title = article.Title,
                ModifiedOn = article.ModifiedOn,
                PublishedOn = article.PublishedOn
            };

            return viewModel;
        }

        public static List<ArticleViewModel> MapToViewModelList(this List<Article> articles) {
            return articles.Select(x => x.MapToViewModel()).ToList();
        }
    }
}
