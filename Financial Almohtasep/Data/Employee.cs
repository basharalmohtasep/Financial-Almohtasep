using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Employees;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_Almohtasep.Data
{
    public class Employee : BaseClass
    {
        [NotMapped]
        public string FullName
        {
            get
            {
                return FName + " " + LName;
            }
        }
        public required string FName { get; set; }
        public required string LName { get; set; }
        public required string PhoneNumper { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Salary { get; set; } = decimal.Zero;
        public DateTime HireDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        public ICollection<EmployeeTransaction> Transaction { get; set; } = [];

        public void Update(EmployeeDtoModel model)
        {
            FName = model.FName;
            LName = model.LName;
            PhoneNumper = model.PhoneNumper;
            Salary = model.Salary;
            HireDate = model.HireDate;
        }
    }
}