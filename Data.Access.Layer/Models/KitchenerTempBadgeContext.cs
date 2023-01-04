using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Access.Layer.Models;

public partial class KitchenerTempBadgeContext : IdentityDbContext
{
    public KitchenerTempBadgeContext()
    {
    }

    public KitchenerTempBadgeContext(DbContextOptions<KitchenerTempBadgeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Gaurd> Gaurds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CJHLT-1590\\SQLEXPRESS;Initial Catalog=KitchenerTempBadge;Encrypt=False;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // changes made
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Empcode);

            entity.ToTable("Employee");

            entity.Property(e => e.Empcode).ValueGeneratedNever();
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Gaurd>(entity =>
        {
            entity.ToTable("Gaurd");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            //=========== change =========
            //entity.Property(e => e.TempBadge).UseIdentityColumn().HasDefaultValueSql("NULL");

            entity.HasOne(d => d.EmpCodeNavigation).WithMany(p => p.Gaurds)
                .HasForeignKey(d => d.EmpCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gaurd_Employee");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
