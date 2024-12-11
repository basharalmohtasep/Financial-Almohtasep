using System.ComponentModel.DataAnnotations;
using Financial_Almohtasep.Data;
namespace Financial_Almohtasep.Models
{
    public class EmployeeDtoModel
    {
        public EmployeeDtoModel() { }
        public EmployeeDtoModel(Employee employee)
        {
            FName = employee.FName;
            LName = employee.LName;
            PhoneNumper = employee.PhoneNumper;
            Salary = employee.Salary;
            HireDate = employee.HireDate;
        }

        public Guid Id { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters.")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters.")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression(@"^\+9627[789]\d{7}$", ErrorMessage = "Enter a valid Jordanian phone number.")]
        public string PhoneNumper { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
        public double Salary { get; set; } // Monthly salary

        [Required(ErrorMessage = "Hire Date is required.")]
        [DataType(DataType.Date)]

        public DateTime HireDate { get; set; }

    }
}