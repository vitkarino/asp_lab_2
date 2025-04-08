using lab_2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace lab_2.Controllers;

public class EmployeeController : Controller
{
    private static List<Employee> _employees = new()
    {
        new Employee { Id = 1, FullName = "Олена Іваненко", Phone = "0501234567", Position = "Терапевт" },
        new Employee { Id = 2, FullName = "Андрій Коваль", Phone = "0672345678", Position = "Хірург" },
    };

    public IActionResult Index()
    {
        return View(_employees);
    }
}