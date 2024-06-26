﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieTickets.Core.Domain.Entities;

[Table("Movie")]
public partial class Movie
{
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(500)]
    [Unicode(false)]
    public string Title { get; set; }

    public int? DurationInMinutes { get; set; }

    [InverseProperty("Movie")]
    public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();

    [InverseProperty("Movie")]
    public virtual ICollection<MovieDirector> MovieDirectors { get; set; } = new List<MovieDirector>();

    [InverseProperty("Movie")]
    public virtual ICollection<MovieGender> MovieGenders { get; set; } = new List<MovieGender>();
}
