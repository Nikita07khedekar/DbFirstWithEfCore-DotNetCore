using System;
using System.Collections.Generic;
using DbFirstWithEfCore.Models;
using Microsoft.EntityFrameworkCore;

namespace DbFirstWithEfCore.Data;

public partial class NikitaContext : DbContext
{
    public NikitaContext()
    {
    }

    public NikitaContext(DbContextOptions<NikitaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=111.118.247.43;Database=Nikita;User ID=Nikita;Password=nikita#1234;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8689616C9");

            entity.Property(e => e.Gender).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
