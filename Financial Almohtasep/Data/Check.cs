using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

using Financial_Almohtasep.Models.Enum;
using Microsoft.VisualBasic;
using Financial_Almohtasep.Models.Checks;
namespace Financial_Almohtasep.Data
{
    public class Check : BaseClass
    {
        public int CheckNumber { get; set; } = 0;
        [ForeignKey(nameof(PayeeID))]
        public Guid PayeeID { get; set; }= Guid.Empty;
        public decimal Amount { get; set; }= decimal.Zero;
        public DateTime DueDate { get; set; }= DateTime.Now;
        public BankName Bank { get; set; }= BankName.None;
        public Currency Currency { get; set; }= Currency.None;
        public string Note { get; set; }= string.Empty;
        public Payee Payee { get; set; }

        public void Update(CheckDtoModel check)
        {
            CheckNumber = check.CheckNumber;
            PayeeID = check.PayeeId;
            Amount = check.Amount;
            DueDate = check.DueDate;
            Bank = check.Bank;
            Currency = check.Currency;
            Note = check.Note;
        }

    }
}
