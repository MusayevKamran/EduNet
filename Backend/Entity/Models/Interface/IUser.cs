using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntityData.Models.Interface
{
    public interface IUser
    {
        List<AppUser> GetUsers();
        Task<List<AppUser>> GetUsersAsync();

        AppUser GetUsersById(Guid? Id);
        Task<AppUser> GetUsersByIdAsync(Guid? Id);

        AppUser CreateUsers(AppUser BrainStormUser);
        Task<AppUser> CreateUsersAsync(AppUser BrainStormUser);

        AppUser UpdateUsers(Guid? Id, AppUser BrainStormUser);
        Task<AppUser> UpdateUsersAsync(Guid? Id, AppUser BrainStormUser);

        void DeleteUsers(Guid? Id);
        Task<AppUser> DeleteUsersAsync(Guid? Id);

        bool UsersExists(Guid id);
    }
}
