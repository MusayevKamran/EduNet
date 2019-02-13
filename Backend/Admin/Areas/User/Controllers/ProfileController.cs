using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AppAdmin.Areas.User.Controllers
{
    [Area("User")]
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}