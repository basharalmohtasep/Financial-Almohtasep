using Financial_Almohtasep.Data;
using System.ComponentModel.DataAnnotations;

namespace Financial_Almohtasep.Models.Dto.Employees
{
    public class EmployeeDtoEdit : EmployeeDtoAdd
    {
        public EmployeeDtoEdit() { }

        public EmployeeDtoEdit(Employee model)
        {
            Id = model.Id;
            FName = model.FName;
            LName = model.LName;
            PhoneNumber = model.PhoneNumber;
            Salary = model.Salary;
            HireDate = model.HireDate;
        }

        public Guid Id { get; set; }

    }
}