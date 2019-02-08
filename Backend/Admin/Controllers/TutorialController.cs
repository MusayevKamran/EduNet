using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AppAdmin.Helpers;
using AppAdmin.Models;
using AppEntity;
using AppEntity.Models;
using AppEntity.Models.Enum;
using AppEntity.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppAdmin.Controllers
{
    //[Authorize]
    public class TutorialController : Controller
    {
        private readonly EntityContext _context;
        IUnitService _unitService;


        public TutorialController(EntityContext context, IUnitService unitService)
        {
            _context = context;
            _unitService = unitService;
        }

        public async Task<IActionResult> Index()
        {
            //var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var articles = await _unitService.Article.GetUserTutorialsAsync(Guid.Parse(userId));
            var articles = await _unitService.Article.GetAllAsync();

            var articleModel = articles
                .Select(article => new ArticleDetailModel
                {
                    Id = article.Id,
                    //Category = article.ArticleCategory,
                    Title = article.Title,
                    Row = article.Row,
                    PostCategory = article.PostCategory,
                    CreatedDate = article.CreatedDate,
                    UpdateDate = article.UpdateDate
                }).ToList();

            var articleIndexModel = new ArticleIndexModel
            {
                ArticleDetailModel = articleModel
            };

            return View(articleIndexModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _unitService.Article.GetByIdAsync(id);
            ArticleDetailModel articleDetailModel = new ArticleDetailModel
            {
                Id = article.Id,
                //Category = article.ArticleCategory,
                Title = article.Title,
                Row = article.Row,
                PostCategory = article.PostCategory,
                CreatedDate = article.CreatedDate,
                UpdateDate = article.UpdateDate
            };

            if (article == null)
            {
                return NotFound();
            }

            return View(articleDetailModel);
        }


        public IActionResult Create()
        {
            ArticleDetailModel articleDetailModel = new ArticleDetailModel()
            {
                // Category = _unitService.Category.GetAll()
            };
            return View(articleDetailModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArticleDetailModel articleDetailModel, int CategoryId, IFormFile files)
        {
            var article = new Article();
            var userId = Guid.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            //List<ArticleCategory> articleCategory = new List<ArticleCategory>() { };
            //var category = await _unitService.Category.GetByIdAsync(CategoryId);
            //ArticleCategory cat = new ArticleCategory { Category = category };
            //articleCategory.Add(cat);

            article.Title = articleDetailModel.Title;
            article.Row = articleDetailModel.Row;
            article.Content = articleDetailModel.Content;

            //article.ArticleCategory = articleCategory;
            article.PostCategory = PostCategory.Tutorial;
            article.CreatedDate = DateTime.Now;
            article.UpdateDate = DateTime.Now;
            article.AppUser = await _unitService.User.GetUsersByIdAsync(userId);
            article.Row = _context.Articles.Any() == false ? 1 : _context.Articles.Max(item => item.Row + 1);

            if (ModelState.IsValid)
            {
                _unitService.Article.Create(article);
                _unitService.SaveChanges();
                if (files != null && files.Length > 0)
                {
                    ImageHelper imageHelper = new ImageHelper(_context);
                    imageHelper.UpdateImage(article.Id, files, "article", article);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(articleDetailModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var article = await _unitService.Article.GetByIdAsync(id);
            ArticleDetailModel articleDetailModel = new ArticleDetailModel()
            {
                Id = article.Id,
                Title = article.Title,
                //Category =article.ArticleCategory,
                Row = article.Row,
                Content = article.Content,
                PostCategory = article.PostCategory,
                CreatedDate = article.CreatedDate,
                UpdateDate = article.UpdateDate
            };

            //var articleCategory = await _unitService.ArticleCategory.getCategoryByArticleIdAsync(id);
            //var catId = articleCategory.First().CategoryId;
            //var catName = await _unitService.Category.GetByIdAsync(catId);
            //ViewBag.category = catName.Name;

            if (article.Image == null)
            {
                article.Image = "images/article/default_article.jpg";
                await _context.SaveChangesAsync();
            }
            if (article == null)
            {
                return NotFound();
            }
            return View(articleDetailModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArticleDetailModel articleDetailModel, int CategoryId, IFormFile files)
        {
            var article = await _unitService.Article.GetByIdAsync(id);

            if (ModelState.IsValid)
            {
                try
                {
                    article.Title = articleDetailModel.Title;
                    article.URL = $@"{articleDetailModel.Title}_{articleDetailModel.Id}";
                    article.Row = articleDetailModel.Row;

                    if (CategoryId != 0)
                    {
                        var articleCategory = _unitService.ArticleCategory.updateArticleCategoryAsync(id, CategoryId);
                    }

                    article.Content = articleDetailModel.Content;
                    article.UpdateDate = DateTime.Now;
                    _unitService.Article.Update(article);
                    _unitService.SaveChanges();

                    if (files != null && files.Length > 0)
                    {
                        ImageHelper imageHelper = new ImageHelper(_context);
                        imageHelper.UpdateImage(id, files, "article", article);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(articleDetailModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(article);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _unitService.Article.GetByIdAsync(id);
            var articleDetailModel = new ArticleDetailModel
            {
                Id = article.Id,
                Title = article.Title,
                Row = article.Row,
                Content = article.Content,
                //Category = article.ArticleCategory,
                PostCategory = article.PostCategory,
                CreatedDate = article.CreatedDate,
                UpdateDate = article.UpdateDate
            };

            if (article == null)
            {
                return NotFound();
            }

            return View(articleDetailModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Article article)
        {
            _unitService.Article.DeleteConfirmed(article);
            _unitService.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _unitService.Article.Exists(id);
        }
    }
}
