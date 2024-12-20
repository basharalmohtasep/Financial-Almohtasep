using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Base;
using Financial_Almohtasep.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;

public class CheckDto
{
    public List<Check> Checks { get; set; }=new List<Check>();
    public List<BaseIdNameModel<Guid>> BaseIdNameModel { get; set; }= new List<BaseIdNameModel<Guid>>();
}
