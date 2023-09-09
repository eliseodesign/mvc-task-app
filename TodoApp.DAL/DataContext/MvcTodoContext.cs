using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TodoApp.EN;

namespace TodoApp.DAL.DataContext;

public partial class MvcTodoContext : DbContext
{
    public MvcTodoContext()
    {
    }

    public MvcTodoContext(DbContextOptions<MvcTodoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tarea> Tareas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tarea__3214EC075FB2F164");

            entity.ToTable("Tarea");

            entity.Property(e => e.Completada).HasDefaultValueSql("((0))");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
