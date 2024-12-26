using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Base;
using Financial_Almohtasep.Models.Dto.Clinets;

namespace Financial_Almohtasep.Services.ClinetServices
{
    public interface IClinetService
    {
        Task<List<ClinetDto>> GetAll();
        Task<Clinet> GetById(Guid id);
        Task<int> Add(ClinetDtoAdd model);
        Task<int> Edit(ClinetDtoEdit model, Guid id);
        Task<int> Delete(Guid id);
    }
}
