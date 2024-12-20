using Financial_Almohtasep.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_Almohtasep.Models.Employees
{
    public class EmployeeDto(Employee employee)
    {
        [Required(ErrorMessage = "Employee ID is required.")]
        public Guid Id { get; set; } = employee.Id;
        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters.")]
        public string FullName { get; set; } = employee.FullName;
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\+9627[789]\d{7}$", ErrorMessage = "Invalid Jordanian phone number format.")]
        public string PhoneNumper { get; set; } = employee.PhoneNumper;
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value.")]
        public decimal Salary { get; set; } = employee.Salary;
        [Range(0, double.MaxValue, ErrorMessage = "Final amount must be a positive value.")]
        public decimal FinalAmount { get; set; } = employee.Transaction.Sum(I => I.SalaryChange);
        [Required(ErrorMessage = "Hire date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime HireDate { get; set; } = employee.HireDate;

    }
}
