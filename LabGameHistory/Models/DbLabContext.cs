using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LabGameHistory.Models;

public partial class DbLabContext : DbContext
{
    public DbLabContext()
    {
    }

    public DbLabContext(DbContextOptions<DbLabContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CountriName> CountriNames { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GameCompani> GameCompanis { get; set; }

    public virtual DbSet<GameGenre> GameGenres { get; set; }

    public virtual DbSet<GameInfo> GameInfos { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= TheChoomba; Database=DB_LAB; Trusted_Connection=True; Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CountriName>(entity =>
        {
            entity.ToTable("CountriName");

            entity.Property(e => e.Country).HasMaxLength(50);
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.ToTable("Game");

            entity.HasOne(d => d.GameInfo).WithMany(p => p.Games)
                .HasForeignKey(d => d.GameInfoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Game_GameInfo");
        });

        modelBuilder.Entity<GameCompani>(entity =>
        {
            entity.ToTable("GameCompani");

            entity.Property(e => e.CompaniName).HasMaxLength(50);

            entity.HasOne(d => d.CompaniCountry).WithMany(p => p.GameCompanis)
                .HasForeignKey(d => d.CompaniCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GameCompani_CountriName");
        });

        modelBuilder.Entity<GameGenre>(entity =>
        {
            entity.ToTable("GameGenre");

            entity.HasOne(d => d.Genre).WithMany(p => p.GameGenres)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GameGenre_Game");

            entity.HasOne(d => d.GenreNavigation).WithMany(p => p.GameGenres)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GameGenre_Genre");
        });

        modelBuilder.Entity<GameInfo>(entity =>
        {
            entity.ToTable("GameInfo");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.GameDesigner).HasMaxLength(50);
            entity.Property(e => e.MainCharacter).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.GameCompani).WithMany(p => p.GameInfos)
                .HasForeignKey(d => d.GameCompaniId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GameInfo_GameCompani");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("Genre");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("Review");

            entity.Property(e => e.Review1)
                .HasColumnType("text")
                .HasColumnName("Review");

            entity.HasOne(d => d.Game).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Review_Game");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
