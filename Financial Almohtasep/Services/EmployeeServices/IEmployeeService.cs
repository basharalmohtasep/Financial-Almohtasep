using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Financial_Almohtasep.Services.EmployeeService
{
    public interface IEmployeeService
    {

        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(Guid id);
        Task<float> GetEmployeesSalary(EmployeeTransactionViewModel model);
        Task<int> AddEmployee(EmployeeViewModel employee);
        Task<int> EditEmployee(EmployeeDtoModel model, Guid id);
        Task<int> DeleteEmployee(Guid id);
    }
}
