using AppEntity.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AppContract
{
    public interface IArticleDAL : IRepository<Article>
    {
        bool Exists(int id);
        Task<List<Article>> GetUserArticlesAsync(Guid Id);

        Task<List<Article>> GetTutorialsAsync();
        Task<List<Article>> GetBlogsAsync();

        Task<List<Article>> GetUserTutorialsAsync(Guid Id);
        Task<List<Article>> GetUserBlogsAsync(Guid Id);

    }
}
