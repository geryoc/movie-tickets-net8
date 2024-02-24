using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieTickets.Core.Domain.Entities;

[Table("Gender")]
public partial class Gender
{
    [Key]
    public short Id { get; set; }

    [Required]
    [StringLength(500)]
    [Unicode(false)]
    public string Name { get; set; }

    [InverseProperty("Gender")]
    public virtual ICollection<MovieGender> MovieGenders { get; set; } = new List<MovieGender>();
}
