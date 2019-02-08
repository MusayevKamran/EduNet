using AppEntity;
using AppEntity.Models;
using AppEntity.Models.Enum;
using AppEntity.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppService
{
    public class ArticleService : GenericService<Article>, IArticle
    {

        public ArticleService(EntityContext context) : base(context)
        { }

        public EntityContext context
        {
            get { return _context as EntityContext; }
        }

        public bool Exists(int id)
        {
            return context.Articles.Any(e => e.Id == id);
        }

        public async Task<List<Article>> GetBlogsAsync()
        {
            return await context.Articles
                     .Where(article => article.PostCategory == PostCategory.Blog)
                     .ToListAsync();
        }

        public async Task<List<Article>> GetTutorialsAsync()
        {
            return await context.Articles
                    .Where(article => article.PostCategory == PostCategory.Tutorial)
                    .ToListAsync();
        }

        public async Task<List<Article>> GetUserArticlesAsync(Guid Id)
        {
            return await context.Articles
                        .Where(m => m.AppUser.Id == Id)
                        .ToListAsync();
        }

        public async Task<List<Article>> GetUserBlogsAsync(Guid Id)
        {
            return await context.Articles
                                .Where(article => article.AppUser.Id == Id && article.PostCategory == PostCategory.Blog)
                                .ToListAsync();
        }

        public async Task<List<Article>> GetUserTutorialsAsync(Guid Id)
        {
            return await context.Articles
                                .Where(article => article.AppUser.Id == Id && article.PostCategory == PostCategory.Tutorial)
                                .ToListAsync();
        }
    }
}
