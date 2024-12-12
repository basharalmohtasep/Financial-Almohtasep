using Financial_Almohtasep.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_Almohtasep.Models.Employees
{
    public class EmployeeDto(Employee employee)
    {
        public Guid Id { get; set; } = employee.Id;
        public string FullName { get; set; } = employee.FullName;
        public string PhoneNumper { get; set; } = employee.PhoneNumper;
        public decimal Salary { get; set; } = employee.Salary;
        public decimal FinalAmount { get; set; } = employee.Transaction.Sum(I => I.SalaryChange);
        public DateTime HireDate { get; set; } = employee.HireDate;

    }
}
