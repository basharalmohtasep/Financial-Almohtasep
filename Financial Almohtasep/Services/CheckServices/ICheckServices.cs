using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Base;
using Financial_Almohtasep.Models.Checks;

namespace Financial_Almohtasep.Services.CheckServices
{
    public interface ICheckServices
    {
        Task<List<Check>> GetAll(Guid? PayeeId = null, DateTime? StartDate = null, DateTime? EndDate = null);
        Task<Check> GetById(Guid Id);
        Task<int> Add(CheckViewModel model);
        Task<int> Edit(CheckDtoModel model, Guid id);
        Task<int> Delete(Guid Id);



    }
}
