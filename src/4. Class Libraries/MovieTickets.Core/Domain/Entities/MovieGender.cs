using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieTickets.Core.Domain.Entities;

[Table("MovieGender")]
[Index("MovieId", "GenderId", Name = "UQ_MovieGender_MovieId_GenderId", IsUnique = true)]
public partial class MovieGender
{
    [Key]
    public long Id { get; set; }

    public long MovieId { get; set; }

    public short GenderId { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    [ForeignKey("GenderId")]
    [InverseProperty("MovieGenders")]
    public virtual Gender Gender { get; set; }

    [ForeignKey("MovieId")]
    [InverseProperty("MovieGenders")]
    public virtual Movie Movie { get; set; }
}
