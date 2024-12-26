using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace Financial_Almohtasep.Services.TransactionServices
{
    public class TransactionServices(ApplicationDbContext context) : ITransactionServices
    {
        private readonly ApplicationDbContext _context = context;

        #region Methods
        public async Task<List<EmployeeTransaction>> GetAllEmployees(Guid? EmployeeId = null, DateTime? StartDate = null, DateTime? EndDate = null)
        {
            return await _context.EmployeeTransaction.AsNoTracking()
                .Where(I =>
                        (EmployeeId == null || EmployeeId.Value.Equals(I.EmployeeId)) &&
                        (StartDate == null || StartDate.Value.Date <= I.TransactionDate) &&
                        (EndDate == null || I.TransactionDate <= EndDate.Value.Date)
                ).ToListAsync();
        }
        public async Task<EmployeeTransaction> GetById(Guid id)
        {
            return await _context.EmployeeTransaction.FindAsync(id);
        }
        public async Task<int> Add(EmployeeTransactionViewModel model)
        {
            if (model.EmployeeId == Guid.Empty)
                return 0;

            var Employee = await _context.Employees.FindAsync(model.EmployeeId);
            if (Employee is null)
                return 0;

            EmployeeTransaction newTransaction = new()
            {
                SalaryChange = CalculateTransaction(model.TransactionType, model.SalaryChange),
                TransactionType = model.TransactionType,
                Note = model.Note,
                TransactionDate = model.TransactionDate,
                EmployeeId = model.EmployeeId,
                Employee = Employee,
            };

            await _context.EmployeeTransaction.AddAsync(newTransaction);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Edit(Guid Id, EmployeeTransactionViewModel model)
        {
            if (Id == Guid.Empty || model.EmployeeId == Guid.Empty)
                return 0;

            var EmployeeTransaction = await _context.EmployeeTransaction.FindAsync(Id);
            if (EmployeeTransaction is null)
                return 0;

            if (EmployeeTransaction.EmployeeId != model.EmployeeId)
                return 0;

            EmployeeTransaction.SalaryChange = CalculateTransaction(model.TransactionType, model.SalaryChange);
            EmployeeTransaction.TransactionType = model.TransactionType;
            EmployeeTransaction.Note = model.Note;
            EmployeeTransaction.TransactionDate = model.TransactionDate;

            _context.EmployeeTransaction.Update(EmployeeTransaction);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Calculates the result of the transaction based on the TransactionType.
        /// Ensure that `TransactionType` and `PreviousCompensation` and `CompensationChange` are set before calling this method.
        /// </summary>
        /// <returns>The calculated compensation after applying the transaction.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the TransactionType is invalid.</exception>
        public static decimal CalculateTransaction(TransactionType Type, decimal value)
        {
            return Type switch
            {
                TransactionType.Salary => +value,
                TransactionType.Withdrawal => -value,
                TransactionType.Bonus => +value,
                TransactionType.Deduction => -value,
                _ => throw new InvalidOperationException("Invalid transaction type provided.")
            };
        }
        #endregion
    }
}