using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class ContactManagementContext : DbContext
{
    public ContactManagementContext()
    {
    }

    public ContactManagementContext(DbContextOptions<ContactManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ContactInfo> ContactInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-EOU16SFT\\SQLEXPRESS;Initial Catalog=ContactManagement;User ID=sa;Password=123456;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactInfo>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__ContactI__5C66259B1BCEFF84");

            entity.ToTable("ContactInfo");

            entity.HasIndex(e => e.ContactName, "UQ__ContactI__773EFFFDE69D9667").IsUnique();

            entity.Property(e => e.BirthDay).HasColumnType("datetime");
            entity.Property(e => e.ContactName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GroupName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HireDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
