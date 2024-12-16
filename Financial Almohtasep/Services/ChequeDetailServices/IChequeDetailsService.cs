using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Cheque;
namespace Financial_Almohtasep.Services.ChequeDetailServices
{
    public interface IChequeDetailsService
    {
        Task<List<ChequeDetails>> GetAll();
        Task<ChequeDetails> GetById(Guid id);
        Task<int> Add(ChequeDetailViewModel model);
        Task<int> Addpayee(PayeeViewModel model);
        Task<int> Edit(ChequeDetailDtoModel model, Guid id);
        Task<int> Delete(Guid id);
        Task<List<Payees>> GetAllPayees();
    }
}
