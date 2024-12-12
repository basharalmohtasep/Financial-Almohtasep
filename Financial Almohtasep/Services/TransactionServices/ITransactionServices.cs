using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models;
namespace Financial_Almohtasep.Services.TransactionServices
{
    public interface ITransactionServices
    {

        Task<List<EmployeeTransaction>> GetAllEmployeen();
        Task<List<EmployeeTransaction>> GetTransactionByEmployeeId(Guid id);
        Task<EmployeeTransaction> GetTransactionById(Guid id);
        Task<double> GetEmployeeNetSalary(EmployeeTransactionViewModel model);
        Task<int> AddEmployeeTransaction(EmployeeTransactionViewModel model);
        Task<int> EditEmployeeTransaction(EmployeeTransactionViewModel model, Guid id);
        Task<int> DeleteEmployeTransactione(Guid id);
        Task<List<EmployeeTransaction>> GetFilteredEmployeeTransactions(Guid? employeeId, DateTime? startDate, DateTime? endDate);


    }
}
