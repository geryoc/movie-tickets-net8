using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieTickets.Core.Domain.Entities;

[Table("MovieDirector")]
[Index("MovieId", "PersonId", Name = "UQ_MovieDirector_MovieId_PersonId", IsUnique = true)]
public partial class MovieDirector
{
    [Key]
    public long Id { get; set; }

    public long MovieId { get; set; }

    public long PersonId { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    [ForeignKey("MovieId")]
    [InverseProperty("MovieDirectors")]
    public virtual Movie Movie { get; set; }

    [ForeignKey("PersonId")]
    [InverseProperty("MovieDirectors")]
    public virtual Person Person { get; set; }
}
