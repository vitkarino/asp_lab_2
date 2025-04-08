using lab_2.Models;
using lab_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace lab_2.Controllers;

public class EmployeeController : Controller
{
    private static readonly string _filePath = "data/employees.json";
    private static List<Employee> _employees = JsonStorageService<Employee>.Load(_filePath);

    [HttpGet]
    public IActionResult Index()
    {
        return View(_employees);
    }

    [HttpPost]
    public IActionResult Index(Employee employee)
    {
        employee.Id = _employees.Count > 0 ? _employees.Max(e => e.Id) + 1 : 1;
        _employees.Add(employee);
        JsonStorageService<Employee>.Save(_employees, _filePath);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public IActionResult Delete(int id)
    {
        _employees = _employees.Where(e => e.Id != id).ToList();
        JsonStorageService<Employee>.Save(_employees, _filePath);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteAll()
    {
        _employees.Clear();
        JsonStorageService<Employee>.Save(_employees, _filePath);
        return RedirectToAction("Index");
    }

}