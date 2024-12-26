using Financial_Almohtasep.Data;

namespace Financial_Almohtasep.Models.Dto.Clinets
{
    public class ClinetDtoEdit : ClinetDtoAdd
    {
        public ClinetDtoEdit()
        {

        }
        public ClinetDtoEdit(Clinet model)
        {
            Id = model.Id;
            Name = model.Name;
            PhoneNumber = model.PhoneNumber;
            Note = model.Note;
        }

        public Guid Id { get; set; }
    }
}