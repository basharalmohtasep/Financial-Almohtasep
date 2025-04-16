using Financial_Almohtasep.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;
namespace Financial_Almohtasep.Data
{
    public class Check : BaseClass
    {
        public int CheckNumber { get; set; } = 0;
        [ForeignKey(nameof(PayeeID))]
        public Guid PayeeID { get; set; } = Guid.Empty;
        public decimal Amount { get; set; } = decimal.Zero;
        public DateTime DueDate { get; set; } = DateTime.Now;
        public BankName Bank { get; set; } = BankName.None;
        public Currency Currency { get; set; } = Currency.None;
        public string Note { get; set; } = string.Empty;

    }
}
