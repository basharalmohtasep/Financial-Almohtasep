using Financial_Almohtasep.Models.Cheque;
using Financial_Almohtasep.Models.Enum;
using System.ComponentModel.DataAnnotations;
namespace Financial_Almohtasep.Data
{
    public class ChequeDetails : BaseClass
    {
        [Required]
        public int ChequeNumber { get; set; } = 0;
        [Required]
        public decimal Amount { get; set; } = decimal.Zero;
        [Required]
        public BankName bankName { get; set; } = BankName.None;
        [Required]
        public Currency currency { get; set; } = Currency.Jd;
        [Required]
        public DateTime DueDate { get; set; } = DateTime.Now;
        public ChequeStatus chequeStatus { get; set; } = ChequeStatus.None;
        public ICollection<Payees> payees { get; set; }
        public void Update(ChequeDetailDtoModel model)
        {
            ChequeNumber = model.ChequeNumber;
            Amount = model.Amount;
            bankName = model.bankName;
            currency = model.currency;
            DueDate = model.DueDate;

        }
    }
}
