﻿using HRM.BAL.Manager;
using HRM.Data.Models;
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
            var employee = _employeeManager.GetAllEmployees();
            return View(employee);
        }
        public IActionResult Details(int id)
        {
            var employee = _employeeManager.GetEmployee(id);
            return View(employee);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeManager.SaveEmployee(employee);
                
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employeeManager.GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeManager.UpdateEmployee(employee);
                _employeeManager.SaveEmployee(employee);
                return RedirectToAction("Index", "Employee");

            }
            else
            {
                return View(employee);
            }
        }
    }
}
