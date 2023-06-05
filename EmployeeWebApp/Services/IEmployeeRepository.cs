using EmployeeWebApp.Models;

namespace EmployeeWebApp.Services;

public interface IEmployeeRepository
{
    IEnumerable<Employee> GetAll();

    Employee? GetById(int id);

    int Add(Employee employee);

    bool Edit(Employee item);

    bool Remove(int id);
}