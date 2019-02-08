using AppEntity;
using AppEntity.Models;
using AppEntity.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppService
{
    public class UserService : IUser
    {
        private EntityContext _context;

        public UserService(EntityContext context)
        {
            this._context = context;
        }

        public AppUser CreateUsers(AppUser brainStormUser)
        {
            brainStormUser.Id = Guid.NewGuid();
            _context.Add(brainStormUser);
            _context.SaveChanges();
            return brainStormUser;
        }

        public async Task<AppUser> CreateUsersAsync(AppUser brainStormUser)
        {
            brainStormUser.Id = Guid.NewGuid();
            brainStormUser.URL = $@"{brainStormUser.UserName}_{brainStormUser.Id}";

            _context.Add(brainStormUser);
            await _context.SaveChangesAsync();
            return brainStormUser;
        }

        public void DeleteUsers(Guid? Id)
        {
            _context.AppUsers.FirstOrDefault(m => m.Id == Id);
        }

        public async Task<AppUser> DeleteUsersAsync(Guid? Id)
        {
            AppUser BrainStormUser = await _context.AppUsers
                .FirstOrDefaultAsync(m => m.Id == Id);
            return BrainStormUser;
        }

        public List<AppUser> GetUsers()
        {
            var BrainStormUser = _context.AppUsers.ToList();
            return BrainStormUser;
        }

        public async Task<List<AppUser>> GetUsersAsync()
        {
            var BrainStormUser = await _context.AppUsers.ToListAsync();
            return BrainStormUser;
        }

        public AppUser GetUsersById(Guid? Id)
        {
            var BrainStormUser = _context.AppUsers.FirstOrDefault(m => m.Id == Id);
            return BrainStormUser;
        }

        public async Task<AppUser> GetUsersByIdAsync(Guid? Id)
        {
            var BrainStormUser = await _context.AppUsers.FirstOrDefaultAsync(m => m.Id == Id);
            return BrainStormUser;
        }

        public AppUser UpdateUsers(Guid? Id, AppUser BrainStormUser)
        {
            _context.Update(BrainStormUser);
            _context.SaveChanges();

            return BrainStormUser;
        }

        public async Task<AppUser> UpdateUsersAsync(Guid? Id, AppUser BrainStormUser)
        {

            _context.Update(BrainStormUser);
            await _context.SaveChangesAsync();

            return BrainStormUser;
        }

        public bool UsersExists(Guid id)
        {
            return _context.AppUsers.Any(e => e.Id == id);
        }
    }
}
