using System.ComponentModel.DataAnnotations;

namespace Financial_Almohtasep.Models.Dto.Clinets
{
    public class ClinetDtoAdd
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression(@"^\+9627[789]\d{7}$", ErrorMessage = "Enter a valid Jordanian phone number.")]
        public string PhoneNumber { get; set; }

        public string Note { get; set; }
    }
}