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
            return View("EditEmployees", users.GetAllEmployees());

        }

        [CustomAuthorization]
        public IActionResult AddTask(Task task)
        {
            TaskDAO tasks = new TaskDAO();
            tasks.AddTask(task);

            return View("ViewTask", tasks.GetAllTasks());
        }

        [CustomAuthorization]
        public IActionResult Delete(int Id)
        {
            UsersDAO user = new UsersDAO();

            user.Delete(Id);
            return View("EditEmployees", user.GetAllEmployees());
        }

        [CustomAuthorization]
        public IActionResult DeleteTask(int Id)
        {
            TaskDAO task = new TaskDAO();
            LinkedDAO link = new LinkedDAO();

            task.DeleteTask(Id);
            link.DeleteTask(Id);
            return View("ViewTask", task.GetAllTasks());
        }

        [CustomAuthorization]
        public IActionResult Edit(int Id)
        {
            UsersDAO user = new UsersDAO();
            return View(user.findUserById(Id));
        }

        [CustomAuthorization]
        public IActionResult SaveEdit(User usermodel)
        {
            UsersDAO user = new UsersDAO();

            user.SaveEdit(usermodel);
            return View("EditEmployees", user.GetAllEmployees());
            
        }

        [CustomAuthorization]
        public IActionResult EditTask(int Id)
        {
            TaskDAO task = new TaskDAO();
            return View(task.findById(Id));
        }

        [CustomAuthorization]
        public IActionResult SaveEditTask(Task task)
        {
            TaskDAO taskE = new TaskDAO();
            taskE.SaveEditTask(task);
            return View("ViewTask", taskE.GetAllTasks());
        }

        [CustomAuthorization]
        public IActionResult Assign(int Id)
        {
            UsersDAO user = new UsersDAO();
            ViewBag.TaskId = Id;
            return View(user.GetAllEmployees());
        }

        [CustomAuthorization]
        public IActionResult AssignTask(string username, int taskId)
        {

            TaskDAO task = new TaskDAO();
            LinkedDAO assign = new LinkedDAO();
            UsersDAO user = new UsersDAO();
            assign.addAssigned(user.findUser(username).Id, taskId);
            return View("Index");
        }

        [CustomAuthorization]
        public IActionResult Details(int Id)
        {

            TaskDAO task = new TaskDAO();
            return View(task.findById(Id));
        }

    }
}
