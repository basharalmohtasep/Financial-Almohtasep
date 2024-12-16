using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Employees;
using Financial_Almohtasep.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Financial_Almohtasep.Models.Cheque
{
    public class ChequeDetailDtoModel(ChequeDetails chequeDetails)
    {
        [Required]
        public int ChequeNumber { get; set; }=chequeDetails.ChequeNumber;
        [Required]
        public decimal Amount { get; set; } = chequeDetails.Amount;
        [Required]
        public BankName bankName { get; set; } = chequeDetails.bankName;
        [Required]
        public Currency currency { get; set; } = chequeDetails.currency;
        [Required]
        public DateTime DueDate { get; set; } =chequeDetails.DueDate;
        
        
    }

    }

