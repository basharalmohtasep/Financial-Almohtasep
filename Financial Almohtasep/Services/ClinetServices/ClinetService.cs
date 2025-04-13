using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Base;
using Financial_Almohtasep.Models.Dto.Clinets;
using Microsoft.EntityFrameworkCore;

namespace Financial_Almohtasep.Services.ClinetServices
{
    public class ClinetService(ApplicationDbContext context) : IClinetService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<ClinetDto>> GetAll()
        {
            return await _context.Clinets.AsNoTracking()
                .Include(x=>x.Transaction)
                .Select(I => new ClinetDto(I)).ToListAsync();
        }

        public async Task<List<BaseIdNameModel<Guid>>> GetNames()
        {
            return await _context.Clinets.AsNoTracking()
                .Select(a => new BaseIdNameModel<Guid>()
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToListAsync();
        }
        public async Task<Clinet> GetById(Guid id)
        {
            return await _context.Clinets.FindAsync(id);
        }

        public async Task<int> Add(ClinetDtoAdd model)
        {
            if (model is null)
                return 0;

            await _context.Clinets.AddAsync(new Clinet(model));

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Edit(ClinetDtoEdit model, Guid id)
        {
            if (id == Guid.Empty)
            {
                return 0;
            }
            else
            {
                var Clinet = await _context.Clinets.FindAsync(id);
                if (Clinet is null)
                {
                    return 0;
                }
                else
                {
                    Clinet.Update(model);

                    _context.Clinets.Update(Clinet);

                    return await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<int> Delete(Guid id)
        {
            if (id == Guid.Empty) return 0;

            var Clinet = await _context.Clinets.FindAsync(id);

            if (Clinet is null) return 0;

            Clinet.IsDeleted = true;

            return await _context.SaveChangesAsync();
        }
    }
}
