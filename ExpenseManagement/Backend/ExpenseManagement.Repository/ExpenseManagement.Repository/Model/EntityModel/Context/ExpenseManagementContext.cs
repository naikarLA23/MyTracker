using System;
using System.Collections.Generic;
using ExpenseManagement.Repository.Model.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Repository.Model.EntityModel.Context;

public partial class ExpenseManagementContext : DbContext
{
    public ExpenseManagementContext()
    {
    }

    public ExpenseManagementContext(DbContextOptions<ExpenseManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Alert> Alerts { get; set; }

    public virtual DbSet<EmailSetting> EmailSettings { get; set; }

    public virtual DbSet<FriendDetail> FriendDetails { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupExpense> GroupExpenses { get; set; }

    public virtual DbSet<GroupType> GroupTypes { get; set; }

    public virtual DbSet<PushNotificationSetting> PushNotificationSettings { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ANAND_LAPTOP;Database=ExpenseManagement; Integrated Security=True;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.ToTable("Activity");

            entity.Property(e => e.CreatedOn).HasColumnType("smalldatetime");
            entity.Property(e => e.Message).HasMaxLength(500);
        });

        modelBuilder.Entity<Alert>(entity =>
        {
            entity.ToTable("Alert");

            entity.Property(e => e.AlertType).HasMaxLength(20);
            entity.Property(e => e.Comments).HasMaxLength(200);
        });

        modelBuilder.Entity<EmailSetting>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("EmailSetting");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Questions).HasMaxLength(100);
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.ToTable("Group");

            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.GroupName).HasMaxLength(50);
            entity.Property(e => e.Icon).HasMaxLength(100);
            entity.Property(e => e.MemberIds).HasMaxLength(100);
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<GroupExpense>(entity =>
        {
            entity.ToTable("GroupExpense");
        });

        modelBuilder.Entity<GroupType>(entity =>
        {
            entity.ToTable("GroupType");

            entity.Property(e => e.Comments).HasMaxLength(200);
            entity.Property(e => e.GroupType1)
                .HasMaxLength(50)
                .HasColumnName("GroupType");
        });

        modelBuilder.Entity<PushNotificationSetting>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("PushNotificationSetting");

            entity.Property(e => e.UserId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.Property(e => e.Questions).HasMaxLength(500);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Language).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MobileNo).HasMaxLength(20);
            entity.Property(e => e.Otp)
                .HasMaxLength(20)
                .HasColumnName("OTP");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PasswordValidUpto).HasColumnType("smalldatetime");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Token).HasMaxLength(500);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
