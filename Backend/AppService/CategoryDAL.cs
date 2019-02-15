using AppContract;
using AppEntity;
using AppEntity.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppService
{
    public class CategoryDAL : Repository<Category>, ICategoryDAL
    {
        public CategoryDAL(EntityContext context) : base(context)
        { }

        public EntityContext context
        {
            get { return _context as EntityContext; }
        }

        public bool Exists(int id)
        {
            return context.Categories.Any(e => e.Id == id);
        }

        public async Task<List<Category>> GetCategoryListByAticleIdAsync(object obj)
        {
            var categoryList = new List<Category>();

            var articleCategory = await context.ArticleCategories
                .Where(a => a.Category == obj)
                .ToAsyncEnumerable().ToList();

            foreach (var item in articleCategory)
            {
                var category = await context.Categories.FindAsync(item.CategoryId);
                categoryList.Add(category);
            }
            return categoryList;
        }
    }
}
