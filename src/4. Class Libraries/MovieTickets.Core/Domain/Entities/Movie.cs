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
    public string Name { get; set; }
}
