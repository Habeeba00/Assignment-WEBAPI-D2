﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Assignment_WEBAPI_D2.Models;

[Table("Instructor")]
public partial class Instructor
{
    [Key]
    public int Ins_Id { get; set; }

    [StringLength(50)]
    public string Ins_Name { get; set; }

    [StringLength(50)]
    public string Ins_Degree { get; set; }

    public int? Dept_Id { get; set; }

    public int? Salary { get; set; }

    [InverseProperty("Ins")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    [InverseProperty("Dept_ManagerNavigation")]
    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}