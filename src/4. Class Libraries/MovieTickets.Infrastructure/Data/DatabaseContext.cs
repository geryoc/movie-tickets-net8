using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MovieTickets.Core.Domain.Entities;

namespace MovieTickets.Infrastructure.Data;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieActor> MovieActors { get; set; }

    public virtual DbSet<MovieDirector> MovieDirectors { get; set; }

    public virtual DbSet<MovieGender> MovieGenders { get; set; }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovieActor>(entity =>
        {
            entity.HasOne(d => d.Movie).WithMany(p => p.MovieActors).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Person).WithMany(p => p.MovieActors).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<MovieDirector>(entity =>
        {
            entity.HasOne(d => d.Movie).WithMany(p => p.MovieDirectors).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Person).WithMany(p => p.MovieDirectors).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<MovieGender>(entity =>
        {
            entity.HasOne(d => d.Gender).WithMany(p => p.MovieGenders).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieGenders).OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
