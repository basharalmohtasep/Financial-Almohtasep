using Financial_Almohtasep.Models.Enum;
namespace Financial_Almohtasep.Data
{
    public class Payee :BaseClass
    {
        public string Name { get; set; }=string.Empty;
        public string Note { get; set; } = string.Empty;
        public PayeeType Type { get; set; } = PayeeType.None;
        ICollection<Check> checks { get; set; }
    }
}
