using AppEntity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppContract
{
    public interface ICategoryDAL : IRepository<Category>
    {
        bool Exists(int id);
        Task<List<Category>> GetCategoryListByAticleIdAsync(object obj);
    }
}
