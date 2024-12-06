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

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=83.147.246.87;Database=andreev_223_toys_shop_db;Username=kunevitch_223_toys_shop;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.user_id).HasName("user_pk");

            entity.ToTable("user");

            entity.Property(e => e.user_id).HasColumnName("user_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.password)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.polic)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("surname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
