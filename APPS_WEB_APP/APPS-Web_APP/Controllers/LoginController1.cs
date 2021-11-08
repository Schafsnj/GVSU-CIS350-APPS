using APPS_Web_APP.Models;
using APPS_Web_APP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APPS_Web_APP.Controllers
{
    public class LoginController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ProcessLogin(User usermodel)
        {
            SecurityService securityService = new SecurityService();
            if(securityService.IsValid(usermodel))
            {
                if(securityService.checkManager(usermodel))
                {
                    HttpContext.Session.SetString("username", usermodel.UserName);
                    return RedirectToAction("Index", "Manager");
                }
                else
                {
                    return View("Employee", usermodel);
                }

            }
            else
            {
                HttpContext.Session.Remove("username");
                return View("LoginFailure", usermodel);
            }
        }
    }
}
