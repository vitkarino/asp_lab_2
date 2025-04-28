using lab_2.Data;
using lab_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab_2.Controllers;

public class EmployeeController : Controller
{
    private readonly AppDbContext _context;

    public EmployeeController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var employees = _context.Employees.ToList();
        return View(employees);
    }

    [HttpPost]
    public IActionResult Index(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteAll()
    {
        _context.Employees.RemoveRange(_context.Employees);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}