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
        public IActionResult Index()
        {
                return View();
        }

        [CustomAuthorization]
        public IActionResult EditEmployees()
        {
            UsersDAO employees = new UsersDAO();
            return View(employees.GetAllEmployees());
        }


        [CustomAuthorization]
        public IActionResult Create()
        {
 
            return View();
        }

        //[CustomAuthorization]
        public IActionResult AddAccount(User usermodel)
        {
            UsersDAO users = new UsersDAO();
            users.AddUser(usermodel);

            if (users.FindUserByNameAndPassword(usermodel))
            {
                return View("AccountAdded", usermodel);
            }
            else
            {
                return Content("Something Went Wrong");
            }
 
        }


    }
}
