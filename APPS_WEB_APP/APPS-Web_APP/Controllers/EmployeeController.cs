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

namespace APPS_Web_APP.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly APPS_Web_APPContext _context;

        public EmployeeController(APPS_Web_APPContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        public IActionResult ViewTask()
        {
            TaskDAO tasks = new TaskDAO();
            return View(tasks.GetAllTasks());
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
