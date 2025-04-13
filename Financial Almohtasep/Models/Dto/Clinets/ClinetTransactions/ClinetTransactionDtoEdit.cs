using Financial_Almohtasep.Data;

namespace Financial_Almohtasep.Models.Dto.Clinets.ClinetTransactions
{
    public class ClinetTransactionDtoEdit:ClinetTransactionDtoAdd
    {
        public ClinetTransactionDtoEdit() { }
        public ClinetTransactionDtoEdit(ClinetTransaction model)
        {
            Id = model.Id;
            Amount = model.Amount;
            TransactionDate = model.TransactionDate;
            TransactionType = model.TransactionType;
            Note = model.Note;
        }
        public Guid Id { get; set; }
    }
}
