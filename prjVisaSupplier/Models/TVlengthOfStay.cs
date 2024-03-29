﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prjVisaSupplier.Models;

[Table("tVLengthOfStay")]
public partial class TVlengthOfStay
{
    [Key]
    [Column("fId")]
    public int FId { get; set; }

    [Required]
    [Column("fLengthOfStay")]
    [StringLength(50)]
    public string FLengthOfStay { get; set; }

    [InverseProperty("FLengthOfStay")]
    public virtual ICollection<TVproduct> TVproducts { get; set; } = new List<TVproduct>();
}