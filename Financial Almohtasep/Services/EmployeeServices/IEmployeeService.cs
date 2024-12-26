using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Base;
using Financial_Almohtasep.Models.Dto.Employees;

namespace Financial_Almohtasep.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAll();
        Task<List<EmployeeDto>> GetAllWithFinalAmout();
        Task<List<BaseIdNameModel<Guid>>> GetNames();
        Task<Employee> GetById(Guid id);
        Task<decimal> GetNetSalary(Guid id);
        Task<int> Add(EmployeeDtoAdd employee);
        Task<int> Edit(EmployeeDtoEdit model, Guid id);
        Task<int> Delete(Guid id);
    }
}