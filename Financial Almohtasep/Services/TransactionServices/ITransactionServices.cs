using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models;
namespace Financial_Almohtasep.Services.TransactionServices
{
    public interface ITransactionServices
    {

        Task<List<EmployeeTransaction>> GetAllEmployeeTransaction();
        Task<List<EmployeeTransaction>> GetTransactionByEmployeeId(Guid id);
        Task<int> AddEmployeeTransaction(EmployeeTransactionViewModel model);
        Task<int> EditEmployeeTransaction(EmployeeTransactionViewModel model, Guid id);
        Task<int> DeleteEmployeTransactione(Guid id);

    }
}
