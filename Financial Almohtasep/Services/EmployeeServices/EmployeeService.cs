using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models;
using Microsoft.EntityFrameworkCore;
namespace Financial_Almohtasep.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        #region Constructor
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        #endregion

        #region Methods
        public async Task<List<Employee>> GetAllEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees;
        }
        public async Task<Employee> GetEmployeeById(Guid id)
        {
            return await _context.Employees.FindAsync(id);
        }
        public async Task<double> GetEmployeesSalary(EmployeeTransactionViewModel model)
        {
            var Salary = await _context.Employees.Where(x => x.Id == model.EmployeeId).Select(e => e.Salary).SingleOrDefaultAsync();
            if (Salary == 0.0)
            {
                return 0.0f;
            }
            return Salary;
        }
        public async Task<int> AddEmployee(EmployeeViewModel model)
        {
            if (model is null)
                return 0;

            var employee = new Employee
            {
                FName = model.FName,
                LName = model.LName,
                PhoneNumper = model.PhoneNumper,
                Salary = model.Salary,
                HireDate = model.HireDate,
            };

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return 1;
        }
        public async Task<int> EditEmployee(EmployeeDtoModel model, Guid id)
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
                    employee.FName = model.FName;
                    employee.LName = model.LName;
                    employee.PhoneNumper = model.PhoneNumper;
                    employee.Salary = model.Salary;
                    employee.HireDate = model.HireDate;

                    _context.Employees.Update(employee);
                    await _context.SaveChangesAsync();
                    return 1;
                }
            }
        }
        public async Task<int> DeleteEmployee(Guid id)
        {
            if (id == Guid.Empty)
            {
                return 0;
            }
            
            var employee = await _context.Employees.FindAsync(id);
            if (employee is null)
            {
                return 0;
            }
            
            employee.IsDeleted = true;
            await _context.SaveChangesAsync();
            return 1;
        }
        public async Task<List<BaseIdNameModel<Guid>>> List()
        {
            return await _context.Employees.AsNoTracking()
                .Select(a => new BaseIdNameModel<Guid>()
                {
                    Id = a.Id,
                    Name = a.FullName
                }).ToListAsync();
        }
        #endregion
    }
}
