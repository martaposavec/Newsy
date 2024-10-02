using Newsy.Models;

namespace Newsy.Repository.Interfaces
{
    public interface IArticleRepository
    {
        /// <summary>
        /// Get all articles
        /// </summary>
        /// <returns>List of all existing articles</returns>
        List<Article> GetAll();

        /// <summary>
        /// Get all articles from specified author
        /// </summary>
        /// <param name="authorId">ID of the author (user)</param>
        /// <returns>List of all articles written by the specified author</returns>
        List<Article> GetByAuthorId(int authorId);

        /// <summary>
        /// Get article by ID
        /// </summary>
        /// <param name="id">ID of wanted article</param>
        /// <returns>Data about specified article</returns>
        Article Get(int id);

        /// <summary>
        /// Save new article
        /// </summary>
        /// <param name="article">Data to save</param>
        void Save(Article article);

        /// <summary>
        /// Update existing article
        /// </summary>
        /// <param name="article">Data to save</param>
        void Update(Article article);

        /// <summary>
        /// Delete specific article by given ID
        /// </summary>
        /// <param name="id">ID of the article to delete</param>
        void Delete(int id);
    }
}
