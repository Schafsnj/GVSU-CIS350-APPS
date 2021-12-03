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
            UsersDAO userDB = new UsersDAO();
            if(userDB.FindUserByNameAndPassword(usermodel))
            {
                if(userDB.checkManager(usermodel))
                {
                    HttpContext.Session.SetString("username", usermodel.UserName);
                    return RedirectToAction("Index", "Manager");
                }
                else
                {
                    if(userDB.checkLoggedIn(usermodel))
                    {
                        return View("ChangePassword", usermodel);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Employee");
                    }
                    
                }

            }
            else
            {
                HttpContext.Session.Remove("username");
                return View("LoginFailure", usermodel);
            }
        }
        public ActionResult ChangePassword(User usermodel)
        {
            return View(usermodel);
        }

        public ActionResult SavePassword(User usermodel)
        {
            UsersDAO users = new UsersDAO();
            users.changePassword(usermodel);
            return RedirectToAction("Index", "Employee");
        }
        
    }
}
