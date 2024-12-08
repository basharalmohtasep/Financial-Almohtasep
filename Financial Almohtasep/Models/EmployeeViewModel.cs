using Financial_Almohtasep.Data;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace Financial_Almohtasep.Models
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
        [Range(0, float.MaxValue, ErrorMessage = "Salary must be a positive number.")]
        public float Salary { get; set; } // Monthly salary

        [Required(ErrorMessage = "Hire Date is required.")]
        [DataType(DataType.Date)]
        
        public DateTime HireDate { get; set; }

       
    }
}
