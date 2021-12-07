using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APPS_Web_APP.Data;
using APPS_Web_APP.Models;
using APPS_Web_APP.Services;
using Microsoft.AspNetCore.Http;

namespace APPS_Web_APP.Controllers
{
    public class EmployeeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewTask()
        {
            TaskDAO tasks = new TaskDAO();
            LinkedDAO link = new LinkedDAO();
            UsersDAO user = new UsersDAO();
            return View(tasks.GetAllTasksAssigned(link.getAssigned(user.findUser(HttpContext.Session.GetString("username")))));
        }
        public IActionResult Details(int Id)
        {
            TaskDAO tasks = new TaskDAO();
            return View(tasks.findById(Id));
        }

        public IActionResult Complete(int Id)
        {
            TaskDAO tasks = new TaskDAO();
            LinkedDAO link = new LinkedDAO();
            UsersDAO user = new UsersDAO();
            tasks.updateStatus(Id);
            link.remove(Id, user.findUser(HttpContext.Session.GetString("username")));
            return View("ViewTask", tasks.GetAllTasksAssigned(link.getAssigned(user.findUser(HttpContext.Session.GetString("username")))));
        }
    }
}
