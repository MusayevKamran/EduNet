using AppEntity.Models.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppAdmin.Areas.Admin.Controllers
{  
    [Area("User")]
    //[Authorize(Roles = UserStatus.ADMIN)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}