using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Resort.Models;

namespace Resort.Context;

public partial class KlimBaseContext : DbContext
{
    public KlimBaseContext()
    {
    }

    public KlimBaseContext(DbContextOptions<KlimBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<HistoryLogin> HistoryLogins { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Passport> Passports { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=89.110.53.87:5522; Database=klim_base; Username=klim; Password=nissan");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("clients_pk");

            entity.ToTable("clients", "demo1103");

            entity.Property(e => e.ClientId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("client_id");
            entity.Property(e => e.ClientAdres)
                .HasColumnType("character varying")
                .HasColumnName("client_adres");
            entity.Property(e => e.ClientBirthday).HasColumnName("client_birthday");
            entity.Property(e => e.ClientCode)
                .HasColumnType("character varying")
                .HasColumnName("client_code");
            entity.Property(e => e.ClientEmail)
                .HasColumnType("character varying")
                .HasColumnName("client_email");
            entity.Property(e => e.ClientName)
                .HasColumnType("character varying")
                .HasColumnName("client_name");
            entity.Property(e => e.ClientPassword)
                .HasColumnType("character varying")
                .HasColumnName("client_password");
        });

        modelBuilder.Entity<HistoryLogin>(entity =>
        {
            entity.HasKey(e => e.IdLogin).HasName("history_login_pk");

            entity.ToTable("history_login", "demo1103");

            entity.Property(e => e.IdLogin)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_login");
            entity.Property(e => e.LoginComplete).HasColumnName("login_complete");
            entity.Property(e => e.LoginDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("login_date");
            entity.Property(e => e.UserLogin)
                .HasColumnType("character varying")
                .HasColumnName("user_login");
            entity.Property(e => e.UserName)
                .HasColumnType("character varying")
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("orders_pk");

            entity.ToTable("orders", "demo1103");

            entity.Property(e => e.OrderId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("order_id");
        });

        modelBuilder.Entity<Passport>(entity =>
        {
            entity.HasKey(e => e.PassId).HasName("passport_pk");

            entity.ToTable("passport", "demo1103");

            entity.Property(e => e.PassId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("pass_id");
            entity.Property(e => e.PassNumber)
                .HasColumnType("character varying")
                .HasColumnName("pass_number");
            entity.Property(e => e.PassOwner).HasColumnName("pass_owner");
            entity.Property(e => e.PassSeria)
                .HasColumnType("character varying")
                .HasColumnName("pass_seria");

            entity.HasOne(d => d.PassOwnerNavigation).WithMany(p => p.Passports)
                .HasForeignKey(d => d.PassOwner)
                .HasConstraintName("passport_clients_fk");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("post_pk");

            entity.ToTable("post", "demo1103");

            entity.Property(e => e.PostId)
                .ValueGeneratedNever()
                .HasColumnName("post_id");
            entity.Property(e => e.PostTitle)
                .HasColumnType("character varying")
                .HasColumnName("post_title");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("services_pk");

            entity.ToTable("services", "demo1103");

            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.ServiceCode)
                .HasColumnType("character varying")
                .HasColumnName("service_code");
            entity.Property(e => e.ServiceCost).HasColumnName("service_cost");
            entity.Property(e => e.ServiceName)
                .HasColumnType("character varying")
                .HasColumnName("service_name");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("staff_pk");

            entity.ToTable("staff", "demo1103");

            entity.Property(e => e.StaffId)
                .HasColumnType("character varying")
                .HasColumnName("staff_id");
            entity.Property(e => e.StaffLastLogIn)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("staff_last_log_in");
            entity.Property(e => e.StaffLogInType).HasColumnName("staff_log_in_type");
            entity.Property(e => e.StaffLogin)
                .HasColumnType("character varying")
                .HasColumnName("staff_login");
            entity.Property(e => e.StaffName)
                .HasColumnType("character varying")
                .HasColumnName("staff_name");
            entity.Property(e => e.StaffPassword)
                .HasColumnType("character varying")
                .HasColumnName("staff_password");
            entity.Property(e => e.StaffPost).HasColumnName("staff_post");

            entity.HasOne(d => d.StaffPostNavigation).WithMany(p => p.Staff)
                .HasForeignKey(d => d.StaffPost)
                .HasConstraintName("staff_post_fk");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("status_pk");

            entity.ToTable("status", "demo1103");

            entity.Property(e => e.StatusId)
                .ValueGeneratedNever()
                .HasColumnName("status_id");
            entity.Property(e => e.StatusName)
                .HasColumnType("character varying")
                .HasColumnName("status_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
