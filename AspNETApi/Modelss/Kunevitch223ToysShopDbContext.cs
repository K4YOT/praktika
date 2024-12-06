using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AspNETApi.Modelss;

public partial class Andreev223ToysShopDbContext : DbContext
{
    public Andreev223ToysShopDbContext()
    {
    }

    public Andreev223ToysShopDbContext(DbContextOptions<Andreev223ToysShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Consultant> Consultants { get; set; }

    public virtual DbSet<Consultation> Consultations { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=83.147.246.87;Database=kunevitch_223_toys_shop_db;Username=kunevitch_223_toys_shop;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("car_pkey");

            entity.ToTable("car");

            entity.HasIndex(e => e.Price, "car_pk").IsUnique();

            entity.Property(e => e.CarId).HasColumnName("car_id");
            entity.Property(e => e.Body)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("body");
            entity.Property(e => e.Box)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("box");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("brand");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("color");
            entity.Property(e => e.Engine)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("engine");
            entity.Property(e => e.Isreserved).HasColumnName("isreserved");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("model");
            entity.Property(e => e.Ownership).HasColumnName("ownership");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.YearOfIssue).HasColumnName("year_of_issue");
        });

        modelBuilder.Entity<Consultant>(entity =>
        {
            entity.HasKey(e => e.ConsultantId).HasName("consultant_pkey");

            entity.ToTable("consultant");

            entity.Property(e => e.ConsultantId)
                .HasDefaultValueSql("nextval('consultant_consultant_seq'::regclass)")
                .HasColumnName("consultant_id");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Consultation>(entity =>
        {
            entity.HasKey(e => e.ConsultationId).HasName("consultation_pkey");

            entity.ToTable("consultation");

            entity.HasIndex(e => e.ConsultantId, "consultation_pk").IsUnique();

            entity.HasIndex(e => e.UserId, "consultation_pk_2").IsUnique();

            entity.HasIndex(e => e.CarId, "consultation_pk_3").IsUnique();

            entity.Property(e => e.ConsultationId).HasColumnName("consultation_id");
            entity.Property(e => e.CarId).HasColumnName("car_id");
            entity.Property(e => e.ConsultantId).HasColumnName("consultant_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Car).WithOne(p => p.Consultation)
                .HasForeignKey<Consultation>(d => d.CarId)
                .HasConstraintName("consultation_car_car_id_fk");

            entity.HasOne(d => d.Consultant).WithOne(p => p.Consultation)
                .HasForeignKey<Consultation>(d => d.ConsultantId)
                .HasConstraintName("consultation_consultant_consultant_id_fk");

            entity.HasOne(d => d.User).WithOne(p => p.Consultation)
                .HasForeignKey<Consultation>(d => d.UserId)
                .HasConstraintName("consultation_user_user_id_fk");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.ManagerId).HasName("manager_pkey");

            entity.ToTable("manager");

            entity.HasIndex(e => e.OrderId, "manager_pk").IsUnique();

            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.OrderId)
                .HasDefaultValueSql("nextval('order_order_id_seq'::regclass)")
                .HasColumnName("order_id");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("surname");

            entity.HasOne(d => d.Order).WithOne(p => p.Manager)
                .HasForeignKey<Manager>(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("manager_order_order_id_fk");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("order_pkey");

            entity.ToTable("order");

            entity.HasIndex(e => e.CarId, "order_pk").IsUnique();

            entity.HasIndex(e => e.UserId, "order_pk_2").IsUnique();

            entity.HasIndex(e => e.Price, "order_pk_3").IsUnique();

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.CarId)
                .ValueGeneratedOnAdd()
                .HasColumnName("car_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("user_id");

            entity.HasOne(d => d.Car).WithOne(p => p.OrderCar)
                .HasForeignKey<Order>(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_car_car_id_fk");

            entity.HasOne(d => d.PriceNavigation).WithOne(p => p.OrderPriceNavigation)
                .HasPrincipalKey<Car>(p => p.Price)
                .HasForeignKey<Order>(d => d.Price)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_car_price_fk");

            entity.HasOne(d => d.User).WithOne(p => p.Order)
                .HasForeignKey<Order>(d => d.UserId)
                .HasConstraintName("order_user_user_id_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("user_pk");

            entity.ToTable("user");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("surname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
