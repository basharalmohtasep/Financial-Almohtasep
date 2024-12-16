using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;
using Financial_Almohtasep.Models.Enum;
namespace Financial_Almohtasep.Data
{
    public class Payees:BaseClass
    {
        [Required]
        public string FullName {  get; set; } = string.Empty;
        [Required]
        public PayeeType PayeeTypes { get; set; } = PayeeType.None;
        public string PhoneNumber { get; set; }=string.Empty;
        public string Notes { get; set; }= string.Empty;
        [ForeignKey(nameof(ChequeId))]
        public Guid ChequeId {  get; set; }
        public ChequeDetails ChequeDetails { get; set; }


    }
}
