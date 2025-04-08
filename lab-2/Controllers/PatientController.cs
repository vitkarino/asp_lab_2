using lab_2.Models;
using lab_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace lab_2.Controllers;

public class PatientController : Controller
{
    private static readonly string _filePath = "data/patients.json";
    private static List<Patient> _patients = JsonStorageService<Patient>.Load(_filePath);

    [HttpGet]
    public IActionResult Index()
    {
        return View(_patients);
    }

    [HttpPost]
    public IActionResult Index(Patient patient)
    {
        patient.Id = _patients.Count > 0 ? _patients.Max(p => p.Id) + 1 : 1;
        _patients.Add(patient);
        JsonStorageService<Patient>.Save(_patients, _filePath);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public IActionResult Delete(int id)
    {
        _patients = _patients.Where(p => p.Id != id).ToList();
        JsonStorageService<Patient>.Save(_patients, _filePath);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteAll()
    {
        _patients.Clear();
        JsonStorageService<Patient>.Save(_patients, _filePath);
        return RedirectToAction("Index");
    }

}