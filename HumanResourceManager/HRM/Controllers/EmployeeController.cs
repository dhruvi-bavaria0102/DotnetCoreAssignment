using HRM.BAL.Manager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeManager _employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        public IActionResult Index()
        {
            return View(_employeeManager.GetAllEmployees());
        }
    }
}
