using lab_2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace lab_2.Controllers;

public class PatientController : Controller
{
    private static List<Patient> _patients = new()
    {
        new Patient { Id = 1, Name = "Марія Петренко", Age = 29, Gender = "Ж" },
        new Patient { Id = 2, Name = "Іван Сидоренко", Age = 42, Gender = "Ч" },
    };

    public IActionResult Index()
    {
        return View(_patients);
    }
}