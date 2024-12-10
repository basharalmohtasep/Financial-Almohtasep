using Financial_Almohtasep.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_Almohtasep.Data
{
    public class EmployeeNetSalary:BaseClass
    {
        public float NetSalary { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Guid EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
