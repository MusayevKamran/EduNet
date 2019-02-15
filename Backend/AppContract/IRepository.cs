using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppContract
{
    //class T nin reference type olması demekdir, (String, class  və s.)
    //IEntity Model Type olmalıdır deməkdir. (Entity Model olması)
    //new()  yenilənə bilən olması deməkdir. (new Class()) new en sonda olmalıdı.
    public interface IRepository<T> where T : class, new()
    {
        void Create(T model);
        void DeleteConfirmed(T model);
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        T GetById(int? Id);
        Task<T> GetByIdAsync(int? Id);
        void Update(T model);
    }
}
