using EmployeeWebApp.Models;
using EmployeeWebApp.Services;
using EmployeeWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApp.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public IActionResult Index()
    {
        var employees = _employeeRepository.GetAll();

        return View(employees);
    }

    public IActionResult Details(int id)
    {
        var employee = _employeeRepository.GetById(id);

        if (employee == null)
        {
            return NotFound();
        }
        
        var employeeViewModel = new EmployeesViewModels()
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Birthday = employee.Birthday
        };
        
        return View(employeeViewModel);
    }

    public IActionResult Create()
    {
        return View("Update", new EmployeesViewModels());
    }

    public IActionResult Update(EmployeesViewModels model)
    {
        var employee = new Employee()
        {
            Id = model.Id,
            LastName = model.LastName,
            FirstName = model.FirstName,
            Birthday = model.Birthday
        };

        if (employee.Id == 0)
        {
            var id = _employeeRepository.Add(employee);
            return RedirectToAction("Details", new { id });
        }

        var success = _employeeRepository.Edit(employee);

        if (!success)
        {
            return NotFound();
        }
        
        return RedirectToAction("Index");
    }

    public IActionResult UpdateById(int id)
    {
        return View("Update");
    }
    
    public IActionResult Delete(int id)
    {
        var employee = _employeeRepository.GetById(id);

        if (employee == null)
        {
            return NotFound();
        }
        
        var employeeViewModel = new EmployeesViewModels()
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Birthday = employee.Birthday
        };
        
        return View(employeeViewModel);
    }

    public IActionResult DeleteConfirm(int id)
    {
        bool employeeWasFound = _employeeRepository.Remove(id);

        if (!employeeWasFound)
        {
            return NotFound();
        }
        
        var employees = _employeeRepository.GetAll();

        return View("Index", employees);
    }
}