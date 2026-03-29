using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace VocabHub.Data.Models;

public partial class VocabHubDbContext : DbContext
{

    public VocabHubDbContext()
    {
    }


    public VocabHubDbContext(DbContextOptions<VocabHubDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Story> Stories { get; set; }

    public virtual DbSet<StoryWord> StoryWords { get; set; }

    public virtual DbSet<UserWordKnowledge> UserWordKnowledges { get; set; }

    public virtual DbSet<Word> Words { get; set; }

    public virtual DbSet<WordExample> WordExamples { get; set; }

    public virtual DbSet<WordMeaning> WordMeanings { get; set; }

    public virtual DbSet<WordSimilarity> WordSimilarities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

        

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Story>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Stories__3214EC0739FA0461");

            entity.HasIndex(e => e.CreatedAt, "IX_Stories_CreatedAt");

            entity.HasIndex(e => e.CreatedByUserId, "IX_Stories_CreatedByUserId");
            

            entity.Property(e => e.Title).HasMaxLength(200);
        });

        modelBuilder.Entity<StoryWord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StoryWor__3214EC0796FBA90A");

            entity.HasIndex(e => e.StoryId, "IX_StoryWords_StoryId");

            entity.HasIndex(e => e.WordId, "IX_StoryWords_WordId");

            entity.HasOne(d => d.Story).WithMany(p => p.StoryWords)
                .HasForeignKey(d => d.StoryId)
                .HasConstraintName("FK_StoryWords_Stories");

            entity.HasOne(d => d.Word).WithMany(p => p.StoryWords)
                .HasForeignKey(d => d.WordId)
                .HasConstraintName("FK_StoryWords_Words");
        });

        modelBuilder.Entity<UserWordKnowledge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserWord__3214EC07AE7E669E");

            entity.ToTable("UserWordKnowledge");

            entity.HasIndex(e => new { e.UserId, e.WordId }, "IX_UserWordKnowledge_UserId_WordId").IsUnique();

            entity.HasIndex(e => e.WordId, "IX_UserWordKnowledge_WordId");

            entity.HasOne(d => d.Word).WithMany(p => p.UserWordKnowledges)
                .HasForeignKey(d => d.WordId)
                .HasConstraintName("FK_UserWordKnowledge_Words");
        });

        modelBuilder.Entity<Word>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Words__3214EC07AC232EB3");

            entity.HasIndex(e => e.Text, "IX_Words_Text");

            entity.HasIndex(e => e.Text, "UQ_Words_Text").IsUnique();

            entity.Property(e => e.Pronunciation).HasMaxLength(200);
            entity.Property(e => e.Text).HasMaxLength(100);
        });

        modelBuilder.Entity<WordExample>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WordExam__3214EC07C3143091");

            entity.HasIndex(e => e.MeaningId, "IX_WordExamples_MeaningId");


            entity.HasOne(d => d.Meaning).WithMany(p => p.WordExamples)
                .HasForeignKey(d => d.MeaningId)
                .HasConstraintName("FK_WordExamples_Meanings");
          
        });

        modelBuilder.Entity<WordMeaning>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WordMean__3214EC0703B6E986");

            entity.HasIndex(e => e.WordId, "IX_WordMeanings_WordId");

            entity.Property(e => e.PartOfSpeech).HasMaxLength(50);

            entity.HasOne(d => d.Word).WithMany(p => p.WordMeanings)
                .HasForeignKey(d => d.WordId)
                .HasConstraintName("FK_WordMeanings_Words");
        });

        modelBuilder.Entity<WordSimilarity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WordSimi__3214EC073BE5EF45");

            entity.HasIndex(e => e.SimilarWordId, "IX_WordSimilarities_SimilarWordId");

            entity.HasIndex(e => e.WordId, "IX_WordSimilarities_WordId");

            entity.Property(e => e.RelationType).HasMaxLength(100);

            entity.HasOne(d => d.SimilarWord).WithMany(p => p.WordSimilaritySimilarWords)
                .HasForeignKey(d => d.SimilarWordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WordSimilarities_SimilarWords");

            entity.HasOne(d => d.Word).WithMany(p => p.WordSimilarityWords)
                .HasForeignKey(d => d.WordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WordSimilarities_Words");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
