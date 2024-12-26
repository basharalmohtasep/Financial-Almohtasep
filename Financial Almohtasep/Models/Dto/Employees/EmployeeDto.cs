using Financial_Almohtasep.Data;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Financial_Almohtasep.Models.Dto.Employees
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {

        }
        public EmployeeDto(Employee model)
        {
            Id = model.Id;
            FName = model.FName;
            LName = model.LName;
            PhoneNumber = model.PhoneNumber;
            Salary = model.Salary;
            FinalAmount = model.Transaction.Sum(I => I.SalaryChange); ;
            HireDate = model.HireDate;
        }
        public Guid Id { get; set; }
        public string FullName
        {
            get
            {
                return FName + " " + LName;
            }
        }
        public string FName { get; set; }
        public string LName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Salary { get; set; }
        public decimal FinalAmount { get; set; }
        public DateTime HireDate { get; set; }

    }
}
