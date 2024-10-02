using Newsy.ViewModels;

namespace Newsy.Services.Interfaces
{
    public interface IArticleService
    {
        /// <summary>
        /// Get all articles
        /// </summary>
        /// <returns>List of all existing articles</returns>
        List<ArticleViewModel> GetAllArticles();

        /// <summary>
        /// Get articles by specified author
        /// </summary>
        /// <param name="authorId">ID of wanted author (user)</param>
        /// <returns>List of all articles written by specified author</returns>
        List<ArticleViewModel> GetArticlesByAuthorId(int authorId);

        /// <summary>
        /// Get article by ID
        /// </summary>
        /// <param name="id">ID of wanted article</param>
        /// <returns>Article data</returns>
        ArticleViewModel GetArticleById(int id);

        /// <summary>
        /// Add new article
        /// </summary>
        /// <param name="viewModel">Article data to save</param>
        /// <param name="currentUserName">Username of currently logged in user</param>
        /// <returns>ID of the newly added article</returns>
        int AddArticle(AddEditArticleViewModel viewModel, string currentUserName);

        /// <summary>
        /// Edit existing article
        /// </summary>
        /// <param name="viewModel">Article data to save</param>
        /// <param name="currentUserName">Username of currently logged in user</param>
        void EditArticle(AddEditArticleViewModel viewModel, string currentUserName);

        /// <summary>
        /// Delete existing article
        /// </summary>
        /// <param name="id">ID of the article</param>
        /// <param name="currentUserName">Username of currently logged in user</param>
        void DeleteArticle(int id, string currentUserName);
    }
}
