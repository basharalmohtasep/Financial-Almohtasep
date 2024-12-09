using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models;
using Microsoft.EntityFrameworkCore;
namespace Financial_Almohtasep.Services
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

     
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        
        public async Task<Employee> GetEmployeeByIdAsync(Guid id)
        {
            return await _context.Employees.FindAsync(id);
        }

        
        public async Task<int> AddEmployeeAsync(EmployeeViewModel model)
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

        
        public async Task<int> EditEmployeeAsync(EmployeeDtoModel model, Guid id)
        {
            if (id == Guid.Empty)
                return 0;

            var employee = await _context.Employees.FindAsync(id);
            if (employee is null)
                return 0;

            employee.FName = model.FName;
            employee.LName = model.LName;
            employee.PhoneNumper = model.PhoneNumper;
            employee.Salary = model.Salary;
            employee.HireDate = model.HireDate;

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return 1;
        }


        public async Task<int> DeleteEmployeeAsync(Guid id)
        {
            if (id == Guid.Empty)
                return 0;

            var employee = await _context.Employees.FindAsync(id);
            if (employee is null)
                return 0;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return 1;
        }

        #endregion
    }
}
