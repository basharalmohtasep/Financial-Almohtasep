﻿using Financial_Almohtasep.Models.Dto.Clinets;
using System.ComponentModel.DataAnnotations;

namespace Financial_Almohtasep.Data;

public class Clinet : BaseClass
{
    public Clinet()
    {

    }
    public Clinet(ClinetDtoAdd model)
    {
        Name = model.Name;
        PhoneNumber = model.PhoneNumber;
        Note = model.Note;
    }

    [Required]
    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public string Note { get; set; }

    public bool IsDeleted { get; set; }

    public ICollection<ClinetTransaction> Transaction { get; set; }

    public void Update(ClinetDtoEdit model)
    {
        Name = model.Name;
        PhoneNumber = model.PhoneNumber;
        Note = model.Note;
    }
}
