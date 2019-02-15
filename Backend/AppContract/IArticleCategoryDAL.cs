using AppEntity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppContract
{
    public interface IArticleCategoryDAL : IRepository<ArticleCategory>
    {
        Task<List<ArticleCategory>> getArticleByCategoryIdAsync(int id);
        Task<List<ArticleCategory>> getCategoryByArticleIdAsync(int id);

        ArticleCategory updateArticleCategoryAsync(int articleId, int categoryId);
    }
}
