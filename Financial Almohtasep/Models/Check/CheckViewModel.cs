using Financial_Almohtasep.Models.Base;
using Financial_Almohtasep.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Financial_Almohtasep.Models.Checks
{
    public class CheckViewModel
    {
        [Required]
        [Display(Name = "Checks Number")]
        [Range(1, int.MaxValue, ErrorMessage = "Checks number must be a positive integer.")]
        public int CheckNumber { get; set; } = 0;

        [Required(ErrorMessage = "Pyees ID is required.")]
        [Display(Name = "Pyees")]
        public Guid PayeeId { get; set; }= Guid.Empty;

        [Required(ErrorMessage = "Amount is required.")]
        [Display(Name = "Amount")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }= decimal.Zero;

        [Required(ErrorMessage = "Due date is required.")]
        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }= DateTime.Now;

        [Required(ErrorMessage = "Bank name is required.")]
        public BankName Bank { get; set; } = BankName.None;

        [Required(ErrorMessage = "Currency is required.")]
        public Currency Currency { get; set; }= Currency.None;

        [Display(Name = "Note")]
        [StringLength(500, ErrorMessage = "Note cannot exceed 500 characters.")]
        public string Note { get; set; }= string.Empty;

        public List<BaseIdNameModel<Guid>> BaseIdNames { get; set; }
    }
}
