using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Base;
using Financial_Almohtasep.Models.Check;
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
        public async Task<List<BaseIdNameModel<Guid>>> GetPayeesName()
        {
            return await _context.Payees.AsNoTracking()
                                  .Select(x => new BaseIdNameModel<Guid>()
                                  {
                                      Id = x.Id,
                                      Name = x.Name
                                  }).ToListAsync();
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
                Duedate = model.DueDate,
                Bank = model.Bank,
                Currency = model.Currency,
                Note = model.Note,
                PayeeID = Payee.Id,
            };
            await _context.Checks.AddAsync(Newcheck);
            return await _context.SaveChangesAsync();
        }
        public async Task<int>AddPayee(PayeeViewModel model)
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

        #endregion
    }
}
