using Financial_Almohtasep.Data;
using Financial_Almohtasep.Helper;
using Financial_Almohtasep.Models;
using Financial_Almohtasep.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
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
        public async Task<List<EmployeeTransaction>> GetAllEmployeen()
        {
            var EmployeeTransaction = await _context.EmployeeTransaction.ToListAsync();
            if (EmployeeTransaction == null || EmployeeTransaction.Count == 0)
            {
                return null;
            }
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
        public async Task<double> GetEmployeeNetSalary(EmployeeTransactionViewModel model)
        {
            if (model == null)
            {
                return -1;
            }
            else
            {
                var salary = await _context.Employees.Where(x => x.Id == model.EmployeeId).Select(x => x.Salary).FirstOrDefaultAsync();
                if (salary == 0)
                {
                    return -1;
                }
                else
                {
                    var NetSalary = await _context.EmployeeTransaction
                        .Where(x => x.EmployeeId == model.EmployeeId)
                        .OrderByDescending(x => x.CreatedAt)
                        .Select(x => x.NetSalary)
                        .FirstOrDefaultAsync();
                    if (NetSalary == 0)
                    {
                        NetSalary = salary;
                    }

                    if (model.TransactionType == TransactionType.Bonus)
                    {
                        return NetSalary += model.Amount;
                    }
                    else
                    {
                        return NetSalary -= model.Amount;
                    }
                }
            }
        }
        public async Task<int> AddEmployeeTransaction(EmployeeTransactionViewModel model)
        {
            var NetSalary = await GetEmployeeNetSalary(model);
            if (NetSalary == -1)
            {
                return 0;
            }
            EmployeeTransaction employeeTransaction = new()
            {
                Amount = model.Amount,
                TransactionDate = model.TransactionDate,
                TransactionType = model.TransactionType,
                NetSalary = NetSalary,
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
                    Transaction.Amount = model.Amount;
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
        public async Task<List<EmployeeTransaction>> GetFilteredEmployeeTransactions(Guid? employeeId, DateTime? startDate, DateTime? endDate)
        {
            
            if (startDate.HasValue && endDate.HasValue)
            {
                return await _context.EmployeeTransaction
                    .Where(x => x.EmployeeId == employeeId && x.TransactionDate >= startDate && x.TransactionDate <= endDate)
                    .ToListAsync();
            }

            
            if (startDate.HasValue)
            {
                return await _context.EmployeeTransaction
                    .Where(x => x.EmployeeId == employeeId && x.TransactionDate >= startDate)
                    .ToListAsync();
            }

            
            if (endDate.HasValue)
            {
                return await _context.EmployeeTransaction
                    .Where(x => x.EmployeeId == employeeId && x.TransactionDate <= endDate)
                    .ToListAsync();
            }

            
            return await _context.EmployeeTransaction
                .Where(x => x.EmployeeId == employeeId)
                .ToListAsync();
        }
        public async Task<List<EmployeeTransaction>> GetFilteredEmployeeTransactions(DateTime? startDate, DateTime? endDate)
        {
            if (startDate.HasValue && endDate.HasValue)
            {
                return await _context.EmployeeTransaction
                    .Where(x => x.TransactionDate >= startDate && x.TransactionDate <= endDate)
                    .ToListAsync();
            }

            if (startDate.HasValue)
            {
                return await _context.EmployeeTransaction
                    .Where(x => x.TransactionDate <= startDate)
                    .ToListAsync();
            }

            if (endDate.HasValue)
            {
                return await _context.EmployeeTransaction
                    .Where(x => x.TransactionDate >= endDate)
                    .ToListAsync();
            }

            return await _context.EmployeeTransaction
                .ToListAsync(); // Return all transactions if no filters are applied
        }




        #endregion
    }
}