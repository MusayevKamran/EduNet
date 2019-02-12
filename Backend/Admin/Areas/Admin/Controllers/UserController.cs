using AppAdmin.Helpers;
using AppEntity;
using AppEntity.Models;
using AppEntity.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AppAdmin.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        EntityContext _context;
        IUnitService _unitService;

        private readonly UserManager<AppUser> _userManager;

        public UserController(EntityContext context, IUnitService unitService,
            UserManager<AppUser> userManager)
        {
            _context = context;
            _unitService = unitService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            return View(await _context.AppUsers.Where(u => u.Id != Guid.Parse(claim.Value)).ToListAsync());
        }
    }
}