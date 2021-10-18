using APPS_Web_APP.Models;
using APPS_Web_APP.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APPS_Web_APP.Controllers
{
    public class AddUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddAccount(User usermodel)
        {
            SecurityService securityService = new SecurityService();
            securityService.AddUser(usermodel);
            return View("AccountAdded", usermodel);
        }
    }
}
