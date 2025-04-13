using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Dto.Clinets.ClinetTransactions;

namespace Financial_Almohtasep.Services.ClinetServices.ClinetTransactionServices
{
    public interface IClinetTransactionService
    {
        Task<List<ClinetTransactionDto>> GetAllClinets(Guid? ClinetId = null, DateTime? StartDate = null, DateTime? EndDate = null);
        Task<ClinetTransaction> GetById(Guid id);
        Task<int> Add(ClinetTransactionDtoAdd model);
        Task<int> Edit(Guid Id, ClinetTransactionDtoEdit model);
    }
}

