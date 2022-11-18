using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DealershipProject.Models;

public partial class DealershipContext : DbContext
{
    public DealershipContext()
    {
    }

    public DealershipContext(DbContextOptions<DealershipContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Claim> Claims { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=dealership;Username=root;Password=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Claim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("claims_pkey");

            entity.ToTable("claims");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Status)
                .HasMaxLength(25)
                .HasColumnName("status");
            entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Claims)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("claims_vehicle_id_fkey");
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("owners_pkey");

            entity.ToTable("owners");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Driverlicense)
                .HasMaxLength(20)
                .HasColumnName("driverlicense");
            entity.Property(e => e.Firstname)
                .HasMaxLength(25)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(25)
                .HasColumnName("lastname");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("vehicles_pkey");

            entity.ToTable("vehicles");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Brand)
                .HasMaxLength(25)
                .HasColumnName("brand");
            entity.Property(e => e.Color)
                .HasMaxLength(25)
                .HasColumnName("color");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.Vin)
                .HasMaxLength(25)
                .HasColumnName("vin");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Owner).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vehicles_owner_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
