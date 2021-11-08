using APPS_Web_APP.Models;
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
    }
}
