using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Financial_Almohtasep.Services
{
    public interface IEmployeeService
    {

        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(Guid id);
        Task<int> AddEmployeeAsync(EmployeeViewModel employee);
        Task<int> EditEmployeeAsync(EmployeeDtoModel model, Guid id);
        Task<int> DeleteEmployeeAsync(Guid id);
    }
}
