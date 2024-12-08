﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Assignment_WEBAPI_D2.Models;

[Table("Course")]
public partial class Course
{
    [Key]
    public int Crs_Id { get; set; }

    [StringLength(50)]
    public string Crs_Name { get; set; }

    public int? Crs_Duration { get; set; }

    public int? Ins_Id { get; set; }

    public int? Top_Id { get; set; }

    [ForeignKey("Ins_Id")]
    [InverseProperty("Courses")]
    public virtual Instructor Ins { get; set; }

    [InverseProperty("Crs")]
    public virtual ICollection<Stud_Course> Stud_Courses { get; set; } = new List<Stud_Course>();

    [ForeignKey("Top_Id")]
    [InverseProperty("Courses")]
    public virtual Topic Top { get; set; }
}