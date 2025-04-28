using lab_2.Data;
using lab_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab_2.Controllers;

public class PatientController : Controller
{
    private readonly AppDbContext _context;

    public PatientController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var patients = _context.Patients.ToList();
        return View(patients);
    }

    [HttpPost]
    public IActionResult Index(Patient patient)
    {
        _context.Patients.Add(patient);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var patient = _context.Patients.Find(id);
        if (patient != null)
        {
            _context.Patients.Remove(patient);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteAll()
    {
        _context.Patients.RemoveRange(_context.Patients);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}