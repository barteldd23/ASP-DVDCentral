﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DDB.DVDCentral.PL;

public partial class DVDCentralEntities : DbContext
{
    public DVDCentralEntities()
    {
    }

    public DVDCentralEntities(DbContextOptions<DVDCentralEntities> options)
        : base(options)
    {
    }

    public virtual DbSet<tblCustomer> tblCustomers { get; set; }

    public virtual DbSet<tblDirector> tblDirectors { get; set; }

    public virtual DbSet<tblFormat> tblFormats { get; set; }

    public virtual DbSet<tblGenre> tblGenres { get; set; }

    public virtual DbSet<tblMovie> tblMovies { get; set; }

    public virtual DbSet<tblMovieGenre> tblMovieGenres { get; set; }

    public virtual DbSet<tblOrder> tblOrders { get; set; }

    public virtual DbSet<tblOrderItem> tblOrderItems { get; set; }

    public virtual DbSet<tblRating> tblRatings { get; set; }

    public virtual DbSet<tblUser> tblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DDB.DVDCentral.DB;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tblCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblCusto__3214EC077EA938B1");

            entity.ToTable("tblCustomer");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblDirector>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblDirec__3214EC076BDECDC0");

            entity.ToTable("tblDirector");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblFormat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblForma__3214EC07B2EF8C35");

            entity.ToTable("tblFormat");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblGenre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblGenre__3214EC07BE110A55");

            entity.ToTable("tblGenre");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblMovie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblMovie__3214EC07A5B07B9C");

            entity.ToTable("tblMovie");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ImagePath)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblMovieGenre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblMovie__3214EC07EDCA8F47");

            entity.ToTable("tblMovieGenre");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<tblOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblOrder__3214EC077B131524");

            entity.ToTable("tblOrder");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.ShipDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<tblOrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblOrder__3214EC07859EA850");

            entity.ToTable("tblOrderItem");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Cost).HasColumnType("money");
        });

        modelBuilder.Entity<tblRating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblRatin__3214EC0790B17893");

            entity.ToTable("tblRating");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblUser__3214EC071A1E6943");

            entity.ToTable("tblUser");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
