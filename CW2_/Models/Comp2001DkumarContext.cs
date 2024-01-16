using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CW2_.Models;

public partial class Comp2001DkumarContext : DbContext
{
    public Comp2001DkumarContext()
    {
    }

    public Comp2001DkumarContext(DbContextOptions<Comp2001DkumarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activite> Activites { get; set; }

    public virtual DbSet<Archive> Archives { get; set; }

    public virtual DbSet<UserActivite> UserActivites { get; set; }

    public virtual DbSet<UserTable> UserTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=dist-6-505.uopnet.plymouth.ac.uk;Database=COMP2001_DKumar;User ID=DKumar; Password=QymF731+;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activite>(entity =>
        {
            entity.HasKey(e => e.FavouriteActivitiesId).HasName("PK__Activite__FA8F451732A82051");

            entity.ToTable("Activites", "CW2");

            entity.Property(e => e.FavouriteActivitiesId).HasColumnName("Favourite_Activities_ID");
            entity.Property(e => e.Activities)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Archive>(entity =>
        {
            entity.HasKey(e => e.ArchiveId).HasName("PK__Archives__F6B65B50A39D8936");

            entity.ToTable("Archives", "CW2");

            entity.Property(e => e.ArchiveId).HasColumnName("Archive_ID");
            entity.Property(e => e.AboutMe)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("about_me");
            entity.Property(e => e.ActivtiyPreference)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Activtiy_Preference");
            entity.Property(e => e.Archive1).HasColumnName("Archive");
            entity.Property(e => e.Birthday)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Height)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MarketingLanguage)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Marketing_Language");
            entity.Property(e => e.Units)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Weight)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserActivite>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("User_Activites", "CW2");

            entity.Property(e => e.FavouriteActivitiesId).HasColumnName("Favourite_Activities_ID");
            entity.Property(e => e.Userid).HasColumnName("USERID");
        });

        modelBuilder.Entity<UserTable>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserTabl__1788CCACD63AB936");

            entity.ToTable("UserTable", "CW2");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.AboutMe)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("about_me");
            entity.Property(e => e.ActivtiyPreference)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Activtiy_Preference");
            entity.Property(e => e.Birthday)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Height)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MarketingLanguage)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Marketing_Language");
            entity.Property(e => e.Units)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Weight)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
