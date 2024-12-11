using Financial_Almohtasep.Data;
using Financial_Almohtasep.Helper;
using Financial_Almohtasep.Models;
using Financial_Almohtasep.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Financial_Almohtasep.Services.TransactionServices
{
    public class TransactionServices : ITransactionServices
    {
        #region Constructor
        private readonly ApplicationDbContext _context;
        public TransactionServices() { }
        public TransactionServices(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion
        #region Methods
        public async Task<List<EmployeeTransaction>> GetAllEmployeeTransaction()
        {
            var EmployeeTransaction = await _context.EmployeeTransaction.ToListAsync();
            return EmployeeTransaction;
        }
        public async Task<List<EmployeeTransaction>> GetTransactionByEmployeeId(Guid id)
        {
            if (id == Guid.Empty)
            {
                return null;
            }
            else
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee == null)
                {

                    return null;
                }
                else
                {
                    var employeeTransactions = await _context.EmployeeTransaction
                                                              .Where(x => x.EmployeeId == id)
                                                              .ToListAsync();

                    if (employeeTransactions == null || !employeeTransactions.Any())
                    {
                        return null;
                    }
                    else
                    {
                        return employeeTransactions;
                    }
                }

            }
        }
        public async Task<EmployeeTransaction> GetTransactionById(Guid id)
        {
            return await _context.EmployeeTransaction.FindAsync(id);
        }
        public async Task<float> GetEmployeeNetSalary(EmployeeTransactionViewModel model)
        {
            if (model ==null)
            {
                return 0;
            }
            else
            {
                var salary = await _context.Employees.Where(x => x.Id == model.EmployeeId).Select(x => x.Salary).FirstOrDefaultAsync();
                if (salary == 0)
                {
                    return 0;
                }
                else
                {
                    var NetSalary = await _context.EmployeeTransaction
                        .Where(x=>x.EmployeeId== model.EmployeeId)
                        .OrderByDescending(x=>x.CreatedAt)
                        .Select(x=>x.NetSalary)
                        .FirstOrDefaultAsync();
                    if (NetSalary == 0)
                        NetSalary = salary;

                    if (model.TransactionType == TransactionType.Bonus)
                    {
                        return NetSalary += model.Transaction;
                    }
                    else
                    {
                        return NetSalary -= model.Transaction;
                    }
                }
            }
        }
        public async Task<int> AddEmployeeTransaction(EmployeeTransactionViewModel model)
        {

            var NetSalary=await GetEmployeeNetSalary(model);
                    EmployeeTransaction employeeTransaction = new()
                    {
                        Transaction = model.Transaction,
                        TransactionDate = model.TransactionDate,
                        TransactionType = model.TransactionType,
                        NetSalary= NetSalary,
                        EmployeeId = model.EmployeeId,
                    };
                    await _context.EmployeeTransaction.AddAsync(employeeTransaction);
                    await _context.SaveChangesAsync();
                    return 1;
            
        }
        public async Task<int> EditEmployeeTransaction(EmployeeTransactionViewModel model, Guid id)
        {
            if (id == Guid.Empty)
            {
                return 0;
            }
            else
            {
                var Transaction = await _context.EmployeeTransaction.FindAsync(id);
                if (Transaction is null)
                {
                    return 0;
                }
                else
                {
                    Transaction.Transaction = model.Transaction;
                    _context.EmployeeTransaction.Update(Transaction);
                    _context.SaveChanges();
                    return 1;
                }
            }

        }
        public async Task<int> DeleteEmployeTransactione(Guid id)
        {
            if (id == Guid.Empty)
                return 0;

            var Transaction = await _context.EmployeeTransaction.FindAsync(id);
            if (Transaction is null)
                return 0;

            _context.EmployeeTransaction.Remove(Transaction);
            await _context.SaveChangesAsync();
            return 1;
        }
        
        #endregion
    }
}
