using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Financial_Almohtasep.Models.Cheque
{
    public class ChequeDetailViewModel
    {
        [Required]
        public int ChequeNumber { get; set; } = 0;
        [Required]
        public decimal Amount { get; set; } = decimal.Zero;
        [Required]
        public BankName BankName { get; set; } = BankName.None;
        [Required]
        public Currency Currency { get; set; } = Currency.Jd;
        [Required]
        public DateTime DueDate { get; set; } = DateTime.Now;
        public List<Payees> Payees { get; set; }
        public ChequeDetails MapOriginal => new()
        {
            ChequeNumber = ChequeNumber,
            Amount = Amount,
            bankName = BankName,
            currency = Currency,
            DueDate = DueDate,
        };

    }
}
