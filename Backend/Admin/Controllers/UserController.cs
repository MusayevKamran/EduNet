using AppAdmin.Helpers;
using AppEntity;
using AppEntity.Models;
using AppEntity.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AppAdmin.Controllers
{
    [Authorize]
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

        [Route("admin/user")]
        public IActionResult Index()
        {
            ViewData["Message"] = "Xos Gelmisiniz";

            var Id = _userManager.GetUserId(HttpContext.User);
            AppUser AppUser = _unitService.User.GetUsersById(Guid.Parse(Id));
            if (AppUser.Image == null)
            {
                AppUser.Image = "images/user/default_user.png";
                _context.SaveChanges();
            }
            return View("index", AppUser);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.AppUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Row,Category,Content,PostCategory")] AppUser AppUser, IFormFile files)
        {
            var user = await _unitService.User.GetUsersByIdAsync(AppUser.Id);

            if (id != AppUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _unitService.User.UpdateUsersAsync(id, user);
                    if (files != null && files.Length > 0)
                    {
                        ImageHelper imageHelper = new ImageHelper(_context);
                        imageHelper.UpdateImage(id, files, "user", user);
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(AppUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(AppUser);
        }


        private bool UsersExists(Guid id)
        {
            return _unitService.User.UsersExists(id);
        }
    }
}