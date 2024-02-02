﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prjVisaSupplier.Models;

[Table("tVFormPath")]
public partial class TVformPath
{
    [Key]
    [Column("fId")]
    public int FId { get; set; }

    [Required]
    [Column("fFormName")]
    [StringLength(50)]
    public string FFormName { get; set; }

    [Column("fFormPath")]
    public string FFormPath { get; set; }

    [InverseProperty("FForm")]
    public virtual ICollection<TVproductFormsRequired> TVproductFormsRequireds { get; set; } = new List<TVproductFormsRequired>();
}