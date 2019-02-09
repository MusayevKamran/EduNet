using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppEntity.Models.Interface
{
    public interface ICategory : IGeneric<Category>
    {
        bool Exists(int id);
        Task<List<Category>> GetCategoryListByAticleIdAsync(object obj);
    }
}
