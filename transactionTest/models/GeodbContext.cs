using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace transactionTest.models;

public partial class GeodbContext : DbContext
{
    public GeodbContext()
    {
    }

    public GeodbContext(DbContextOptions<GeodbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<All> Alls { get; set; }

    public virtual DbSet<AllDatum> AllData { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-O2H5BGS\\SQLEXPRESS;Database=GEODB;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<All>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("All");

            entity.Property(e => e.CountryId).HasColumnName("countryId");
            entity.Property(e => e.CountryName).HasMaxLength(250);
            entity.Property(e => e.DistrictName).HasMaxLength(250);
            entity.Property(e => e.DivisionName).HasMaxLength(250);
        });

        modelBuilder.Entity<AllDatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AllData");

            entity.Property(e => e.CountryName).HasMaxLength(250);
            entity.Property(e => e.DistrictName).HasMaxLength(250);
            entity.Property(e => e.DivisionName).HasMaxLength(250);
            entity.Property(e => e.IntDivisionId).HasColumnName("intDivisionId");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.IntId).HasName("PK__Country__11B678D24BA962E6");

            entity.ToTable("Country", "geo");

            entity.Property(e => e.IntId).HasColumnName("intId");
            entity.Property(e => e.DteCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dteCreatedAt");
            entity.Property(e => e.DteUpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("dteUpdatedAt");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isActive");
            entity.Property(e => e.StrCreatedBy)
                .HasMaxLength(250)
                .HasColumnName("strCreatedBy");
            entity.Property(e => e.StrName)
                .HasMaxLength(250)
                .HasColumnName("strName");
            entity.Property(e => e.StrUpdatedBy)
                .HasMaxLength(250)
                .HasColumnName("strUpdatedBy");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.IntId).HasName("PK__District__11B678D2029A6025");

            entity.ToTable("District", "geo");

            entity.Property(e => e.IntId).HasColumnName("intId");
            entity.Property(e => e.DteCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dteCreatedAt");
            entity.Property(e => e.DteUpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("dteUpdatedAt");
            entity.Property(e => e.IntDivisionId).HasColumnName("intDivisionId");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isActive");
            entity.Property(e => e.StrCreatedBy)
                .HasMaxLength(250)
                .HasColumnName("strCreatedBy");
            entity.Property(e => e.StrName)
                .HasMaxLength(250)
                .HasColumnName("strName");
            entity.Property(e => e.StrUpdatedBy)
                .HasMaxLength(250)
                .HasColumnName("strUpdatedBy");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.IntId).HasName("PK__Division__11B678D203C8BE4C");

            entity.ToTable("Division", "geo");

            entity.Property(e => e.IntId).HasColumnName("intId");
            entity.Property(e => e.DteCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dteCreatedAt");
            entity.Property(e => e.DteUpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("dteUpdatedAt");
            entity.Property(e => e.IntCountryId).HasColumnName("intCountryId");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isActive");
            entity.Property(e => e.StrCreatedBy)
                .HasMaxLength(250)
                .HasColumnName("strCreatedBy");
            entity.Property(e => e.StrName)
                .HasMaxLength(250)
                .HasColumnName("strName");
            entity.Property(e => e.StrUpdatedBy)
                .HasMaxLength(250)
                .HasColumnName("strUpdatedBy");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
