using Financial_Almohtasep.Entity;
using System.ComponentModel.DataAnnotations;
namespace Financial_Almohtasep.Models.Employees
{
    public class EmployeeViewModel
    {
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
        public decimal Salary { get; set; } // Monthly salary

        [Required(ErrorMessage = "Hire Date is required.")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        public Employee MapOriginal => new()
        {
            FName = FName,
            LName = LName,
            PhoneNumper = PhoneNumper,
            Salary = Salary,
            HireDate = HireDate,
        };
    }
}
