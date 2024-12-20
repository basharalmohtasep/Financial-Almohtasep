using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Base;
using Financial_Almohtasep.Models.Check;

namespace Financial_Almohtasep.Services.CheckServices
{
    public interface ICheckServices
    {
        Task<List<Check>> GetAll();
        Task<List<BaseIdNameModel<Guid>>> GetPayeesName();
        Task<int> Add(CheckViewModel model);
        Task<int> AddPayee(PayeeViewModel model);

    }
}
