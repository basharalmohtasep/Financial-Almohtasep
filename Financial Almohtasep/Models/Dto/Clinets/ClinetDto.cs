using Financial_Almohtasep.Data;

namespace Financial_Almohtasep.Models.Dto.Clinets
{
    public class ClinetDto
    {
        public ClinetDto()
        {

        }
        public ClinetDto(Clinet model)
        {
            Id = model.Id;
            Name = model.Name;
            PhoneNumber = model.PhoneNumber;
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
}