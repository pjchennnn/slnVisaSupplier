﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prjVisaSupplier.Models;

[Table("tCouponList")]
public partial class TCouponList
{
    [Key]
    [Column("fCoupon_Id")]
    public int FCouponId { get; set; }

    [Column("fCoupon_code")]
    [StringLength(50)]
    public string FCouponCode { get; set; }

    [Column("fCoupon_name")]
    [StringLength(50)]
    public string FCouponName { get; set; }

    [Column("fAmount", TypeName = "money")]
    public decimal? FAmount { get; set; }

    [Column("fStart_date", TypeName = "datetime")]
    public DateTime? FStartDate { get; set; }

    [Column("fEnd_date", TypeName = "datetime")]
    public DateTime? FEndDate { get; set; }

    [Column("fRule")]
    [StringLength(50)]
    public string FRule { get; set; }

    [Column("fProduct_type")]
    public int? FProductType { get; set; }

    [Column("fDiscount", TypeName = "money")]
    public decimal? FDiscount { get; set; }

    [Column("fNote")]
    public string FNote { get; set; }

    [Required]
    [Column("fEnable")]
    public bool? FEnable { get; set; }

    [InverseProperty("FCoupon")]
    public virtual ICollection<TVorder> TVorders { get; set; } = new List<TVorder>();
}