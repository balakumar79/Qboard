using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Qboard.Entities
{
    public partial class QAContext : DbContext
    {
        public QAContext()
        {
        }

        public QAContext(DbContextOptions<QAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<ContempararyLevels> ContempararyLevels { get; set; }
        public virtual DbSet<Exams> Exams { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Initial Catalog=QA;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answers>(entity =>
            {
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(850);

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");
            });

            modelBuilder.Entity<ContempararyLevels>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<Exams>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.ExamName)
                    .IsRequired()
                    .HasMaxLength(650);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.HasOne(d => d.ContempararyLevelNavigation)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.ContempararyLevel)
                    .HasConstraintName("FK__Exam__Contempara__403A8C7D");

                entity.HasOne(d => d.SkillNavigation)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.Skill)
                    .HasConstraintName("FK__Exam__Skill__3E52440B");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.ExamId).HasColumnName("ExamID");

                entity.Property(e => e.IsActove).HasDefaultValueSql("((1))");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Skills>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
