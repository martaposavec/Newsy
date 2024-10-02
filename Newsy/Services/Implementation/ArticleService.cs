using Newsy.Mappers;
using Newsy.Models;
using Newsy.Repository.Interfaces;
using Newsy.Services.Interfaces;
using Newsy.ViewModels;

namespace Newsy.Services.Implementation
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUserRepository _userRepository;

        public ArticleService(IArticleRepository articleRepository, IUserRepository userRepository)
        {
            _articleRepository = articleRepository;
            _userRepository = userRepository;
        }

        public int AddArticle(AddEditArticleViewModel viewModel, string currentUserName)
        {
            var author = _userRepository.GetByUsername(currentUserName) ?? throw new Exception("Current user not found");

            var article = new Article()
            {
                Author = author,
                Content = viewModel.Content,
                PublishedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                Title = viewModel.Title
            };

            _articleRepository.Save(article);
            return article.Id;
        }

        public void DeleteArticle(int id, string currentUserName)
        {
            var article = _articleRepository.Get(id) ?? throw new Exception($"Article with ID {id} not found");

            if (article.Author.Username != currentUserName)
            {
                throw new Exception("Unauthorized");
            }

            _articleRepository.Delete(id);
        }

        public void EditArticle(AddEditArticleViewModel viewModel, string currentUserName)
        {
            if(!viewModel.Id.HasValue || viewModel.Id.Value == 0)
            {
                throw new Exception("Article ID not found");
            }

            var article = _articleRepository.Get(viewModel.Id.Value) ?? throw new Exception($"Article with ID {viewModel.Id.Value} not found");

            if (article.Author.Username != currentUserName)
            {
                throw new Exception("Unauthorized");
            }
            
            article.Content = viewModel.Content;
            article.Title = viewModel.Title;
            article.ModifiedOn = DateTime.Now;

            _articleRepository.Update(article);
        }

        public List<ArticleViewModel> GetAllArticles()
        {
            var articles = _articleRepository.GetAll();
            return articles.MapToViewModelList();
        }

        public ArticleViewModel GetArticleById(int id)
        {
            var article = _articleRepository.Get(id);
            if (article == null) throw new Exception($"Article with ID {id} not found");
            return article.MapToViewModel();
        }

        public List<ArticleViewModel> GetArticlesByAuthorId(int authorId)
        {
            var articles = _articleRepository.GetByAuthorId(authorId);
            return articles.MapToViewModelList();
        }
    }
}
