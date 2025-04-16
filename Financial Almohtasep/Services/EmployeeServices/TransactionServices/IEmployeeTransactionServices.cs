using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Dto.Employees.Transaction;
namespace Financial_Almohtasep.Services.EmployeeServices.TransactionServices
{
    public interface IEmployeeTransactionServices
    {
        Task<List<EmployeeTransaction>> GetAllEmployees(Guid? EmployeeId = null, DateTime? startDate = null, DateTime? endDate = null);
        Task<EmployeeTransaction> GetById(Guid Id);
        Task<int> Add(EmployeeTransactionViewModel model);
        Task<int> Edit(Guid Id, EmployeeTransactionViewModel model);
        Task AddMonthlySalary();
    }
}
