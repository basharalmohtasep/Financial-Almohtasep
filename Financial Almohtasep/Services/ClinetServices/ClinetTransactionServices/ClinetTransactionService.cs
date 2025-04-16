using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Dto.Clinets.ClinetTransactions;
using Financial_Almohtasep.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace Financial_Almohtasep.Services.ClinetServices.ClinetTransactionServices
{
    public class ClinetTransactionService(ApplicationDbContext context) : IClinetTransactionService
    {
        private readonly ApplicationDbContext _context = context;

        #region Method 
        public async Task<List<ClinetTransactionDto>> GetAllClinets(Guid? ClinetId = null, DateTime? StartDate = null, DateTime? EndDate = null)
        {
            return await _context.ClinetsTransaction
                .AsNoTracking()
                .Where(I =>
                    (ClinetId == null || ClinetId.Value.Equals(I.ClinetId)) &&
                    (StartDate == null || StartDate.Value.Date <= I.TransactionDate.Date) &&
                    (EndDate == null || I.TransactionDate.Date <= EndDate.Value.Date))
                .Select(I => new ClinetTransactionDto(I))
                .ToListAsync();
        }

        public async Task<ClinetTransaction> GetById(Guid id)
        {
            return await _context.ClinetsTransaction.FindAsync(id);
        }
        public async Task<int> Add(ClinetTransactionDtoAdd model)
        {
            if (model is null)
                return 0;
            if (model.ClinetId == Guid.Empty)
                return 0;

            var Clinet = await _context.Clinets.FindAsync(model.ClinetId);
            if (Clinet is null)
                return 0;
            ClinetTransaction newTransaction = new(model);
            newTransaction.Amount = CalculateTransaction(model.TransactionType, model.Amount);
            await _context.ClinetsTransaction.AddAsync(newTransaction);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Edit(Guid Id, ClinetTransactionDtoEdit model)
        {
            var ClinetTransaction = await _context.ClinetsTransaction.FindAsync(Id);
            if (ClinetTransaction is null)
                return 0;

            if (ClinetTransaction.ClinetId != model.ClinetId)
                return 0;

            ClinetTransaction.Amount = CalculateTransaction(model.TransactionType, model.Amount);
            ClinetTransaction.Update(model);
            return await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Calculates the impact of a transaction on an account balance based on its type.
        /// </summary>
        /// <param name="Type">The type of the transaction (Credit or Debit).</param>
        /// <param name="value">The monetary value of the transaction.</param>
        /// <returns>
        /// Returns the transaction value:
        /// - Positive for Credit transactions.
        /// - Negative for Debit transactions.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when an invalid transaction type is provided.
        /// </exception>
        public static decimal CalculateTransaction(ClinetTransactionType Type, decimal value)
        {
            return Type switch
            {
                ClinetTransactionType.Credit => +value,
                ClinetTransactionType.Debit => -value,
                _ => throw new InvalidOperationException("Invalid transaction type provided.")
            };
        }

        #endregion
    }
}
