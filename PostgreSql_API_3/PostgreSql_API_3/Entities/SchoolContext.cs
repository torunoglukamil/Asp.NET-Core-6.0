using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PostgreSql_API_3.Entities;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentsDetail> StudentsDetails { get; set; }

    public virtual DbSet<TableLength> TableLengths { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=school;User Id=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("classrooms_pkey");

            entity.ToTable("classrooms");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Branch)
                .HasMaxLength(1)
                .HasColumnName("branch");
            entity.Property(e => e.Grade).HasColumnName("grade");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("students_pkey");

            entity.ToTable("students");

            entity.HasIndex(e => e.Email, "students_email_key").IsUnique();

            entity.HasIndex(e => e.Phone, "students_phone_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.ClassroomId).HasColumnName("classroom_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");

            entity.HasOne(d => d.Classroom).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassroomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("students_fkey_classrooms");
        });

        modelBuilder.Entity<StudentsDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("students_detail");

            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Branch)
                .HasMaxLength(1)
                .HasColumnName("branch");
            entity.Property(e => e.ClassroomId).HasColumnName("classroom_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.Grade).HasColumnName("grade");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<TableLength>(entity =>
        {
            entity.HasKey(e => e.TableName).HasName("table_lengths_pkey");

            entity.ToTable("table_lengths");

            entity.Property(e => e.TableName)
                .HasMaxLength(100)
                .HasColumnName("table_name");
            entity.Property(e => e.Length).HasColumnName("length");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
