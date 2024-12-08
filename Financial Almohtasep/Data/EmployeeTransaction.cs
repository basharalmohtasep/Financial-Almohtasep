using Financial_Almohtasep.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Financial_Almohtasep.Models.Enum;

namespace Financial_Almohtasep.Data
{
    public class EmployeeTransaction : BaseClass
    {
        
        [Required]
        public float Transaction { get; set; }//المسحوبات
        [Required]
        public DateTime TransactionData { get; set; }//تاريخ السحب
        public TransactionType TransactionType { get; set; }
        [Required]
        [ForeignKey(nameof(EmployeeId))]
        public Guid EmployeeId { get; set; }
        public Employee? Employee { get; set; }


    }
}
