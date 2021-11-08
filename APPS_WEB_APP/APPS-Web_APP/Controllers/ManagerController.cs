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
        [HttpGet]
        [CustomAuthorization]
        public ActionResult Index()
        {
                return View();
        }

        [HttpPost]
        [CustomAuthorization]
        public ActionResult EditEmployees()
        {
            UsersDAO employees = new UsersDAO();
            return View();
        }


    }
}
