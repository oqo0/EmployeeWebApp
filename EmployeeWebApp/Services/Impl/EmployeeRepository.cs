using EmployeeWebApp.Models;

namespace EmployeeWebApp.Services.Impl;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly List<Employee> _employees;
    private int _maxFreeId;

    public EmployeeRepository()
    {
        // generate employees
        _employees = Enumerable.Range(1, 9)
            .Select(i => new Employee()
            {
                Id = i,
                FirstName = $"{i}-firstName",
                LastName = $"{i}-lastName",
                Birthday = DateTime.Now.AddYears(-30 + i)
            }).ToList();
        
        _maxFreeId = _employees.Max(x => x.Id) + 1;
    }
    
    public int Add(Employee employee)
    {
        employee.Id = _maxFreeId;
        _employees.Add(employee);
        _maxFreeId++;
        
        return employee.Id;
    }
    
    public IEnumerable<Employee> GetAll() => _employees;

    public Employee? GetById(int id) => _employees.FirstOrDefault(x => x.Id == id);
    
    public bool Edit(Employee item)
    {
        var dbItem = GetById(item.Id);

        if (dbItem == null)
            return false;

        dbItem.FirstName = item.FirstName;
        dbItem.LastName = item.LastName;
        dbItem.Birthday = item.Birthday;

        return true;
    }

    public bool Remove(int id)
    {
        var dbItem = GetById(id);

        if (dbItem == null)
            return false;

        _employees.Remove(dbItem);
        return true;
    }
}