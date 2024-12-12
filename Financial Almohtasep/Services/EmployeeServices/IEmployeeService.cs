using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models;

namespace Financial_Almohtasep.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(Guid id);
        Task<double> GetEmployeesSalary(EmployeeTransactionViewModel model);
        Task<int> AddEmployee(EmployeeViewModel employee);
        Task<int> EditEmployee(EmployeeDtoModel model, Guid id);
        Task<int> DeleteEmployee(Guid id);
        Task<List<BaseIdNameModel<Guid>>> ListName();
    }
}