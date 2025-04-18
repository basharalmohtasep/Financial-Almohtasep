﻿using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Base;

namespace Financial_Almohtasep.Models.Dto.Employees.Transaction
{
    public class EmployeeTransactionDtoModel
    {
        public List<EmployeeTransaction> EmployeeTransaction { get; set; }
        public List<BaseIdNameModel<Guid>> BaseIdNameModel { get; set; }

    }
}
