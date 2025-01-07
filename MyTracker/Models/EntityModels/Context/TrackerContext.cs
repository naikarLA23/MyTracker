using System;
using System.Collections.Generic;
using MyTracker.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace MyTracker.Models.EntityModels.Context;

public partial class TrackerContext : DbContext
{
    public TrackerContext()
    {
    }

    public TrackerContext(DbContextOptions<TrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ExpenseType> ExpenseTypes { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupExpense> GroupExpenses { get; set; }

    public virtual DbSet<IndividualExpense> IndividualExpenses { get; set; }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<MedicineType> MedicineTypes { get; set; }

    public virtual DbSet<PasswordHistory> PasswordHistories { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ANAND_LAPTOP;Database=Tracker; Integrated Security=True;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExpenseType>(entity =>
        {
            entity.ToTable("ExpenseType");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Note).HasMaxLength(500);
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("Gender");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.GenderType).HasMaxLength(20);
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.Property(e => e.AdminIds).HasMaxLength(100);
            entity.Property(e => e.Date)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.MemberIds).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Note).HasMaxLength(100);
        });

        modelBuilder.Entity<GroupExpense>(entity =>
        {
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.ExpenseDetails).HasMaxLength(1000);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.GroupExpenses)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupExpenses_GroupExpenses");

            entity.HasOne(d => d.Expense).WithMany(p => p.GroupExpenses)
                .HasForeignKey(d => d.ExpenseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupExpenses_ExpenseType");
        });

        modelBuilder.Entity<IndividualExpense>(entity =>
        {
            entity.ToTable("IndividualExpense");

            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.Note)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.GroupExpense).WithMany(p => p.IndividualExpenses)
                .HasForeignKey(d => d.GroupExpenseId)
                .HasConstraintName("FK_IndividualExpense_GroupExpenses");

            entity.HasOne(d => d.User).WithMany(p => p.IndividualExpenses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IndividualExpense_Users");
        });

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Consumer).WithMany(p => p.MedicineConsumers)
                .HasForeignKey(d => d.ConsumerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medicines_Users_Consumer");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.MedicineCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medicines_Users_Created");

            entity.HasOne(d => d.MedicineType).WithMany(p => p.Medicines)
                .HasForeignKey(d => d.MedicineTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medicines_MedicineType");
        });

        modelBuilder.Entity<MedicineType>(entity =>
        {
            entity.ToTable("MedicineType");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<PasswordHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PasswordHistory");

            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Note).HasMaxLength(100);
            entity.Property(e => e.RoleType).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.EmailId).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.ResetPin).HasColumnName("ResetPIN");
            entity.Property(e => e.SessionToken).HasMaxLength(500);
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
