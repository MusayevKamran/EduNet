using AppEntity.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppContract
{
    public interface IUserDAL
    {
        List<AppUser> GetUsers();
        Task<List<AppUser>> GetUsersAsync();

        AppUser GetUsersById(Guid? Id);
        Task<AppUser> GetUsersByIdAsync(Guid? Id);

        AppUser CreateUsers(AppUser AppUser);
        Task<AppUser> CreateUsersAsync(AppUser AppUser);

        AppUser UpdateUsers(Guid? Id, AppUser AppUser);
        Task<AppUser> UpdateUsersAsync(Guid? Id, AppUser AppUser);

        void DeleteUsers(Guid? Id);
        Task<AppUser> DeleteUsersAsync(Guid? Id);

        bool UsersExists(Guid id);
    }
}
