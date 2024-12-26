using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Base;

namespace Financial_Almohtasep.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAll();
        Task<List<EmployeeDto>> GetAllWithFinalAmout();
        Task<List<BaseIdNameModel<Guid>>> GetNames();
        Task<Employee> GetById(Guid id);
        Task<decimal> GetNetSalary(Guid id);
        Task<int> Add(EmployeeViewModel employee);
        Task<int> Edit(EmployeeDtoModel model, Guid id);
        Task<int> Delete(Guid id);
    }
}