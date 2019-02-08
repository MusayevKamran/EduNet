using AppEntity;
using AppEntity.Models;
using AppEntity.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AppService
{
    public class CategoryService : GenericService<Category>, ICategory
    {
        public CategoryService(EntityContext context) : base(context)
        { }

        public EntityContext context
        {
            get { return _context as EntityContext; }
        }

        public bool Exists(int id)
        {
            return context.Categories.Any(e => e.Id == id);
        }

        public async Task<ArticleCategory> GetCategoryByIdAsyncExtra(int? Id)
        {
            return await context.ArticleCategories
                .FirstOrDefaultAsync(m => m.CategoryId == Id);
        }
    }
}
