using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Base;
using Financial_Almohtasep.Models.Checks;
using Financial_Almohtasep.Models.Enum;
using Microsoft.EntityFrameworkCore;
namespace Financial_Almohtasep.Services.CheckServices
{
    public class CheckServices(ApplicationDbContext context) : ICheckServices
    {
        readonly private ApplicationDbContext _context = context;
        #region Method
        public async Task<List<Check>> GetAll()
        {
            return await _context.Checks.AsNoTracking().ToListAsync();
        }
        public async Task<Check> GetById(Guid Id)
        {
            return await _context.Checks.FindAsync(Id);
        }
        public async Task<int> Add(CheckViewModel model)
        {
            if(model.PayeeId == Guid.Empty)
                return 0;
            var Payee = await _context.Payees.FindAsync(model.PayeeId);
            if (Payee is null)
                return 0;
            Check Newcheck = new()
            {
                CheckNumber = model.CheckNumber,
                Amount = model.Amount,
                DueDate = model.DueDate,
                Bank = model.Bank,
                Currency = model.Currency,
                Note = model.Note,
                PayeeID = Payee.Id,
            };
            await _context.Checks.AddAsync(Newcheck);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Edit(CheckDtoModel model, Guid id)
        {
            if (id == Guid.Empty)
                return 0;
            var Check =await _context.Checks.FindAsync(id);
            if(Check is null) 
                 return 0;
            Check.Update(model);
            return await _context.SaveChangesAsync();

        }
        public async Task<int> Delete(Guid Id)
        {
            if (Id == Guid.Empty)
                return 0;

            var result = await _context.Checks.FindAsync(Id);
            if (result == null)
            {
                return 0;
            }
            _context.Checks.Remove(result);
            return await _context.SaveChangesAsync();


        }


        #endregion
    }
}
