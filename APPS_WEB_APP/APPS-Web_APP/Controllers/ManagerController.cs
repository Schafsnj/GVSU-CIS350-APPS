using APPS_Web_APP.Models;
using APPS_Web_APP.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APPS_Web_APP.Controllers
{

    
    public class ManagerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult checkLogin(User usermodel)
        {
            SecurityService securityService = new SecurityService();
            if (securityService.checkManager(usermodel))
            {
                return View("Index");
            }
            else
            {
                return RedirectToAction("LoginController1", "LoginController1");
            }
        }
    }
}
