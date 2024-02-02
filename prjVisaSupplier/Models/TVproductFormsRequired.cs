﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prjVisaSupplier.Models;

[Table("tVProductFormsRequired")]
public partial class TVproductFormsRequired
{
    [Key]
    [Column("fId")]
    public int FId { get; set; }

    [Column("fProductId")]
    public int FProductId { get; set; }

    [Column("fFormId")]
    public int FFormId { get; set; }

    [ForeignKey("FFormId")]
    [InverseProperty("TVproductFormsRequireds")]
    public virtual TVformPath FForm { get; set; }

    [ForeignKey("FProductId")]
    [InverseProperty("TVproductFormsRequireds")]
    public virtual TVproduct FProduct { get; set; }
}