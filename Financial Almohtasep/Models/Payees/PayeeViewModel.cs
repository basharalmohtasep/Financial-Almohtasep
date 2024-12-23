using Financial_Almohtasep.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Financial_Almohtasep.Models.Pyees
{
    public class PayeeViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Note cannot exceed 500 characters.")]
        public string Note { get; set; }

        [Required(ErrorMessage = "Pyees type is required.")]
        public PayeeType Type { get; set; }
    }
}
