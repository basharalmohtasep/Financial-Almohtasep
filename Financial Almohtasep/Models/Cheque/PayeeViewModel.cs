using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Financial_Almohtasep.Models.Cheque
{
    public class PayeeViewModel
    {
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        public PayeeType PayeeTypes { get; set; } = PayeeType.None;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public Payees MapOriginal => new()
        {
            FullName = FullName,
            PayeeTypes = PayeeTypes,
            PhoneNumber = PhoneNumber,
            Notes = Notes,
        };
    }
}
