using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Base;
using Financial_Almohtasep.Models.Pyees;
using Microsoft.EntityFrameworkCore;

namespace Financial_Almohtasep.Services.PayeeServices
{
    public class PayeeServices(ApplicationDbContext context):IPayeeServices
    {
        private readonly ApplicationDbContext _context= context;
        #region Method
        public async Task<List<Payee>> GetAll(Guid? id=null)
        {
            return await _context.Payees.AsNoTracking()
                        .Where(I =>
                        (id == null || id.Value.Equals(I.Id))
                       ).ToListAsync();
        }
        public async Task<Payee> GetById(Guid PayeeId)
        {
            return await _context.Payees.FindAsync(PayeeId);
        }
        public async Task<int> Add(PayeeViewModel model)
        {
            Payee Newpayee = new()
            {
                Name = model.Name,
                Note = model.Note,
                Type = model.Type,
            };
            await _context.AddAsync(Newpayee);
            return await _context.SaveChangesAsync();
        }
        public async Task<List<BaseIdNameModel<Guid>>> GetNames()
        {
            return await _context.Payees.AsNoTracking()
                                  .Select(x => new BaseIdNameModel<Guid>()
                                  {
                                      Id = x.Id,
                                      Name = x.Name
                                  }).ToListAsync();
        }
        public async Task<int> Edit(PayeeViewModel model,Guid Id)
        {
            if(Id== Guid.Empty)
            {
                return 0;
            }
            var result = await _context.Payees.FindAsync(Id);
            if(result== null )
            {
                return 0;
            }
            result.Name= model.Name;
            result.Note= model.Note;
            result.Type = model.Type;
             _context.Payees.Update(result);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(Guid Id)
        {
            if (Id == Guid.Empty) 
                return 0;
            
            var result = await _context.Payees.FindAsync(Id);
            if(result== null )
            {
                return 0;
            }
             _context.Payees.Remove(result);
            return await _context.SaveChangesAsync() ;
        

        }
        #endregion
    }
}
