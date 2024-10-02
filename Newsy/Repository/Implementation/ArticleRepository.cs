using Newsy.Data;
using Newsy.Models;
using Newsy.Repository.Interfaces;

namespace Newsy.Repository.Implementation
{
    public class ArticleRepository : IArticleRepository
    {
        private static List<Article> _articles;

        public ArticleRepository()
        {
            _articles = MockData.MockArticles();
        }

        public void Save(Article article)
        {
            var id = _articles.Max(x => x.Id) + 1;
            article.Id = id;
            _articles.Add(article);
        }

        public void Delete(int id)
        {
            var article = _articles.FirstOrDefault(x => x.Id == id);
            if (article == null)
            {
                throw new Exception("Article not found");
            }

            _articles.Remove(article);
        }

        public void Update(Article article)
        {
            var index = _articles.IndexOf(Get(article.Id));
            _articles[index] = article;
        }

        public Article Get(int id)
        {
            return _articles.FirstOrDefault(x => x.Id == id);
        }

        public List<Article> GetAll()
        {
            return _articles;
        }

        public List<Article> GetByAuthorId(int authorId)
        {
            return _articles.Where(x => x.Author.Id == authorId).ToList();
        }
    }
}
