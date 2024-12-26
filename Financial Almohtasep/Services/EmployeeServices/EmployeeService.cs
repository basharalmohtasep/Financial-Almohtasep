using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Base;
using Microsoft.EntityFrameworkCore;
namespace Financial_Almohtasep.Services.EmployeeServices
{
    public class EmployeeService(ApplicationDbContext context) : IEmployeeService
    {
        private readonly ApplicationDbContext _context = context;

        #region Methods
        public async Task<List<Employee>> GetAll()
        {
            return await _context.Employees.AsNoTracking().ToListAsync();
        }
        public async Task<List<EmployeeDto>> GetAllWithFinalAmout()
        {
            return await _context.Employees.AsNoTracking()
                                                    .Include(I => I.Transaction)
                                                    .Select(I => new EmployeeDto(I))
                                                    .ToListAsync();
        }
        public async Task<List<BaseIdNameModel<Guid>>> GetNames()
        {
            return await _context.Employees.AsNoTracking()
                .Select(a => new BaseIdNameModel<Guid>()
                {
                    Id = a.Id,
                    Name = a.FullName
                }).ToListAsync();
        }
        public async Task<Employee> GetById(Guid id)
        {
            return await _context.Employees.FindAsync(id);
        }
        public async Task<decimal> GetNetSalary(Guid id)
        {
            return await _context.EmployeeTransaction.Where(I => I.EmployeeId.Equals(id)).SumAsync(I => I.SalaryChange);
        }
        public async Task<int> Add(EmployeeViewModel model)
        {
            if (model is null)
                return 0;

            await _context.Employees.AddAsync(model.MapOriginal);

            return await _context.SaveChangesAsync();
        }
        public async Task<int> Edit(EmployeeDtoModel model, Guid id)
        {
            if (id == Guid.Empty)
            {
                return 0;
            }
            else
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee is null)
                {
                    return 0;
                }
                else
                {
                    employee.Update(model);

                    _context.Employees.Update(employee);

                    return await _context.SaveChangesAsync();
                }
            }
        }
        public async Task<int> Delete(Guid id)
        {
            if (id == Guid.Empty) return 0;

            var employee = await _context.Employees.FindAsync(id);

            if (employee is null) return 0;

            employee.IsDeleted = true;

            return await _context.SaveChangesAsync();
        }

        #endregion
    }
}
