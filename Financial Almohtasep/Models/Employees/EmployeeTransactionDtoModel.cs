using Financial_Almohtasep.Entity;
using Financial_Almohtasep.Models.Base;

namespace Financial_Almohtasep.Models.Employees
{
    public class EmployeeTransactionDtoModel
    {
        public List<EmployeeTransaction> EmployeeTransaction { get; set; }
        public List<BaseIdNameModel<Guid>> BaseIdNameModel { get; set; }
    }
}
