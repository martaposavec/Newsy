using Newsy.Services.Interfaces;
using Newsy.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Newsy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllArticles()
        {
            try
            {
                var result =  _articleService.GetAllArticles();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByAuthorId/{authorId}")]
        public IActionResult GetArticlesByAuthorId(int authorId)
        {
            var result = _articleService.GetArticlesByAuthorId(authorId);
            return Ok(result);

        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetArticleById(int id)
        {
            var result = _articleService.GetArticleById(id);
            return Ok(result);

        }

        [Authorize]
        [HttpPost("Add")]
        public IActionResult AddArticle([FromBody] AddEditArticleViewModel viewModel)
        {
            try
            {
                var currentUserName = (User.Claims.FirstOrDefault(x => x.Type == "Username")?.Value) ?? throw new Exception("Current user not found.");

                var articleId = _articleService.AddArticle(viewModel, currentUserName);
                return Ok(articleId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize]
        [HttpPost("Edit")]
        public IActionResult EditArticle([FromBody] AddEditArticleViewModel viewModel)
        {
            try
            {
                var currentUserName = (User.Claims.FirstOrDefault(x => x.Type == "Username")?.Value) ?? throw new Exception("Current user not found.");

                _articleService.EditArticle(viewModel, currentUserName);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.Message == "Unauthorized") return Unauthorized();
                return BadRequest(ex.Message);
            }

        }

        [Authorize]
        [HttpPost("Delete/{id}")]
        public IActionResult DeleteArticle(int id)
        {
            try
            {
                var currentUserName = (User.Claims.FirstOrDefault(x => x.Type == "Username")?.Value) ?? throw new Exception("Current user not found.");

                _articleService.DeleteArticle(id, currentUserName);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.Message == "Unauthorized") return Unauthorized();
                return BadRequest(ex.Message);
            }

        }
    }
}
