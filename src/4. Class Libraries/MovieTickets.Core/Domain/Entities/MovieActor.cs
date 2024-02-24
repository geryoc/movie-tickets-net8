using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieTickets.Core.Domain.Entities;

[Table("MovieActor")]
[Index("MovieId", "PersonId", Name = "UQ_MovieActor_MovieId_PersonId", IsUnique = true)]
public partial class MovieActor
{
    [Key]
    public long Id { get; set; }

    public long MovieId { get; set; }

    public long PersonId { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    [ForeignKey("MovieId")]
    [InverseProperty("MovieActors")]
    public virtual Movie Movie { get; set; }

    [ForeignKey("PersonId")]
    [InverseProperty("MovieActors")]
    public virtual Person Person { get; set; }
}
