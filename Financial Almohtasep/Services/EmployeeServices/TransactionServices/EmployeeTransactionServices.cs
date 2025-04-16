using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Dto.Employees.Transaction;
using Financial_Almohtasep.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace Financial_Almohtasep.Services.EmployeeServices.TransactionServices
{
    public class EmployeeTransactionServices(ApplicationDbContext context) : IEmployeeTransactionServices
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
        /// Calculates the result of the transaction based on the EmployeeTransactionType.
        /// Ensure that `EmployeeTransactionType` and `PreviousCompensation` and `CompensationChange` are set before calling this method.
        /// </summary>
        /// <returns>The calculated compensation after applying the transaction.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the EmployeeTransactionType is invalid.</exception>
        public static decimal CalculateTransaction(EmployeeTransactionType Type, decimal value)
        {
            return Type switch
            {
                EmployeeTransactionType.Salary => +value,
                EmployeeTransactionType.Withdrawal => -value,
                EmployeeTransactionType.Bonus => +value,
                EmployeeTransactionType.Deduction => -value,
                _ => throw new InvalidOperationException("Invalid transaction type provided.")
            };
        }
        public async Task AddMonthlySalary()
        {
            var employees = await _context.Employees
                .Where(e => !e.IsDeleted)
                .ToListAsync();

            foreach (var employee in employees)
            {
                // Check if the employee already has a transaction for this month
                var currentMonth = DateTime.UtcNow.Month;
                var currentYear = DateTime.UtcNow.Year;

                bool hasTransactionForThisMonth = await _context.EmployeeTransaction
                    .AnyAsync(t => t.EmployeeId == employee.Id &&
                                   t.TransactionDate.Month == currentMonth &&
                                   t.TransactionDate.Year == currentYear &&
                                   t.TransactionType == EmployeeTransactionType.Salary);

                if (hasTransactionForThisMonth)
                    continue;

                // Check if the employee is new and calculate prorated salary if necessary
                decimal salaryToPay = employee.Salary;
                if (employee.HireDate.Month == currentMonth && employee.HireDate.Year == currentYear)
                {
                    int daysWorked = (DateTime.UtcNow - employee.HireDate).Days + 1;
                    int totalDaysInMonth = DateTime.DaysInMonth(currentYear, currentMonth);
                    salaryToPay = (employee.Salary / totalDaysInMonth) * daysWorked;
                }

                EmployeeTransaction monthlySalaryTransaction = new()
                {
                    SalaryChange = salaryToPay,
                    TransactionType = EmployeeTransactionType.Salary,
                    Note = "Monthly salary payment",
                    TransactionDate = DateTime.UtcNow,
                    EmployeeId = employee.Id,
                    Employee = employee
                };

                await _context.EmployeeTransaction.AddAsync(monthlySalaryTransaction);
            }

            await _context.SaveChangesAsync();
        }
        #endregion
    }
}