using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Base;
using Financial_Almohtasep.Models.Pyees;

namespace Financial_Almohtasep.Services.PayeeServices
{
    public interface IPayeeServices
    {
        Task<List<Payee>> GetAll();
        Task<Payee> GetById(Guid PayeeId);
        Task<int> Add(PayeeViewModel model);
        Task<List<BaseIdNameModel<Guid>>> GetNames();
        Task<int> Edit(PayeeViewModel model,Guid Id);
        Task<int> Delete(Guid Id);
    }
}
