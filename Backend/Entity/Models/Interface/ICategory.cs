using System.Threading.Tasks;

namespace EntityData.Models.Interface
{
    public interface ICategory : IGeneric<Category>
    {
        bool Exists(int id);
        Task<ArticleCategory> GetCategoryByIdAsyncExtra(int? Id);
    }
}
