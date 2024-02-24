using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieTickets.Core.Domain.Entities;

[Table("Person")]
public partial class Person
{
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(500)]
    [Unicode(false)]
    public string FirstName { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string MiddleName { get; set; }

    [Required]
    [StringLength(500)]
    [Unicode(false)]
    public string LastName { get; set; }

    [InverseProperty("Person")]
    public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();

    [InverseProperty("Person")]
    public virtual ICollection<MovieDirector> MovieDirectors { get; set; } = new List<MovieDirector>();
}
