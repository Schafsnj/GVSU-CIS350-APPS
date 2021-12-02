using APPS_Web_APP.Models;
using APPS_Web_APP.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = APPS_Web_APP.Models.Task;

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
        public IActionResult ViewTask()
        {
            TaskDAO tasks = new TaskDAO();
            return View(tasks.GetAllTasks());
        }


        [CustomAuthorization]
        public IActionResult Create()
        {
 
            return View();
        }

        [CustomAuthorization]
        public IActionResult CreateTask()
        {

            return View();
        }

        [CustomAuthorization]
        public IActionResult AddAccount(User usermodel)
        {
            UsersDAO users = new UsersDAO();
            users.AddUser(usermodel);

            return View("AddAccount", usermodel); 
        }

        [CustomAuthorization]
        public IActionResult AddTask(Task task)
        {
            TaskDAO tasks = new TaskDAO();
            tasks.AddTask(task);

            return View("AddTask", task);
        }
        [CustomAuthorization]
        public IActionResult Delete(int Id)
        {
            UsersDAO user = new UsersDAO();
            
            user.Delete(Id);
            return View("EditEmployees", user.GetAllEmployees());
        }


    }
}
