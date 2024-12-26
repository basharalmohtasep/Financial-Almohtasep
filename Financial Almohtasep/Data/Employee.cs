using Financial_Almohtasep.Models.Dto.Clinets;
using Financial_Almohtasep.Models.Dto.Employees;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Financial_Almohtasep.Data
{
    public class Employee : BaseClass
    {
        public Employee()
        {

        }
        public Employee(EmployeeDtoAdd model)
        {
            FName = model.FName;
            LName = model.LName;
            PhoneNumber = model.PhoneNumber;
            Salary = model.Salary;
            HireDate = model.HireDate;
        }

        public string FName { get; set; } = string.Empty;
        public string LName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,4)")]
        public decimal Salary { get; set; } = decimal.Zero;
        public DateTime HireDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        public ICollection<EmployeeTransaction> Transaction { get; set; } = [];

        public void Update(EmployeeDtoEdit model)
        {
            FName = model.FName;
            LName = model.LName;
            PhoneNumber = model.PhoneNumber;
            Salary = model.Salary;
            HireDate = model.HireDate;
        }
    }
}