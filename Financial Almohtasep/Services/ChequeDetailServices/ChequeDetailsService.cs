using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Cheque;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel;

namespace Financial_Almohtasep.Services.ChequeDetailServices
{
    public class ChequeDetailsService(ApplicationDbContext context) : IChequeDetailsService
    {
        private readonly ApplicationDbContext _context = context;
        #region Methods
        public async Task<List<ChequeDetails>> GetAll()
        {
            return await _context.ChequeDetails.AsNoTracking().ToListAsync();
        }
        public async Task<ChequeDetails> GetById(Guid id)
        {
            return await _context.ChequeDetails.FindAsync(id);
        }
        public async Task<int> Add(ChequeDetailViewModel model)
        {
            if (model is null)
                return 0;

            await _context.ChequeDetails.AddAsync(model.MapOriginal);
            return await _context.SaveChangesAsync();
        }
        public async Task<int>Addpayee(PayeeViewModel model)
        {
            if (model is null)
                return 0;

            await _context.Payees.AddAsync(model.MapOriginal);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Edit(ChequeDetailDtoModel model, Guid id)
        {
            if (id == Guid.Empty)
            {
                return 0;
            }
            else
            {
                var Cheque = await _context.ChequeDetails.FindAsync(id);
                if (Cheque is null)
                {
                    return 0;
                }
                else
                {
                    Cheque.Update(model);

                    _context.ChequeDetails.Update(Cheque);

                    return await _context.SaveChangesAsync();
                }
            }
        }
        public async Task<int> Delete(Guid id)
        {
            if (id == Guid.Empty) return 0;

            var Cheque = await _context.ChequeDetails.FindAsync(id);

            if (Cheque is null) return 0;

            return await _context.SaveChangesAsync();
        }
        public async Task<List<Payees>> GetAllPayees()
        {
            return await _context.Payees.AsNoTracking().ToListAsync();
        }
        #endregion
    }  
}
