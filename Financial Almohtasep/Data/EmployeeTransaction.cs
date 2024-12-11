using Financial_Almohtasep.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Financial_Almohtasep.Models.Enum;

namespace Financial_Almohtasep.Data
{
    public class EmployeeTransaction : BaseClass
    {
        [Required]
        public double Amount { get; set; }//المسحوبات
        
        [Required]
        public DateTime TransactionDate { get; set; }//تاريخ السحب
        
        public TransactionType TransactionType { get; set; }
        
        public double NetSalary { get; set; }
        
        [Required]
        [ForeignKey(nameof(EmployeeId))]
        public Guid EmployeeId { get; set; }
        
        public Employee Employee { get; set; }
    }
}