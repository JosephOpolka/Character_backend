using System;
using System.Collections.Generic;
using Character_backend.ScaffoldModels;
using Microsoft.EntityFrameworkCore;

namespace Character_backend.ScaffoldDbContext;

public partial class CharacterCreatorContext : DbContext
{
    public CharacterCreatorContext()
    {
    }

    public CharacterCreatorContext(DbContextOptions<CharacterCreatorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<Relationship> Relationships { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Character_Creator.db;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>(entity =>
        {
            entity.Property(e => e.CharacterId).HasColumnName("character_id");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.EyeColor).HasColumnName("eye_color");
            entity.Property(e => e.FavoriteColor).HasColumnName("favorite_color");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.HairColor).HasColumnName("hair_color");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Hobbies).HasColumnName("hobbies");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Occupation).HasColumnName("occupation");
            entity.Property(e => e.Race).HasColumnName("race");
        });

        modelBuilder.Entity<Relationship>(entity =>
        {
            entity.Property(e => e.RelationshipId).HasColumnName("relationship_id");
            entity.Property(e => e.CharacterId1).HasColumnName("character_id_1");
            entity.Property(e => e.CharacterId2).HasColumnName("character_id_2");
            entity.Property(e => e.RelationshipStatus).HasColumnName("relationship_status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
