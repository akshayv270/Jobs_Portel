using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Jobs_Portel.DataEntity
{
    public partial class Job_PortalContext : DbContext
    {
        public Job_PortalContext()
        {
        }

        public Job_PortalContext(DbContextOptions<Job_PortalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employer> Employers { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<JobSeeker> JobSeekers { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-59IEF9L;Database=Job_Portal;Trusted_Connection=True;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employer>(entity =>
            {
                entity.Property(e => e.EmployerId)
                    .ValueGeneratedNever()
                    .HasColumnName("employer_id");

                entity.Property(e => e.CompanyLogo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("company_logo");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("company_name");

                entity.Property(e => e.CompanyWebsite)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("company_website");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contact_number");

                entity.Property(e => e.Industry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("industry");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.HasOne(d => d.EmployerNavigation)
                    .WithOne(p => p.Employer)
                    .HasForeignKey<Employer>(d => d.EmployerId)
                    .HasConstraintName("FK__Employers__emplo__571DF1D5");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.ApplicationDeadline)
                    .HasColumnType("date")
                    .HasColumnName("application_deadline");

                entity.Property(e => e.EmployerId).HasColumnName("employer_id");

                entity.Property(e => e.JobDescription)
                    .HasColumnType("text")
                    .HasColumnName("job_description");

                entity.Property(e => e.JobRequirements)
                    .HasColumnType("text")
                    .HasColumnName("job_requirements");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("job_title");

                entity.Property(e => e.JobType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("job_type");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.PostedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("posted_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SalaryRange)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("salary_range");

                entity.HasOne(d => d.Employer)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.EmployerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Jobs__employer_i__5BE2A6F2");

                entity.HasMany(d => d.Skills)
                    .WithMany(p => p.Jobs)
                    .UsingEntity<Dictionary<string, object>>(
                        "JobSkill",
                        l => l.HasOne<Skill>().WithMany().HasForeignKey("SkillId").HasConstraintName("FK__Job_Skill__skill__68487DD7"),
                        r => r.HasOne<Job>().WithMany().HasForeignKey("JobId").HasConstraintName("FK__Job_Skill__job_i__6754599E"),
                        j =>
                        {
                            j.HasKey("JobId", "SkillId").HasName("PK__Job_Skil__E1891E9226CCD6BE");

                            j.ToTable("Job_Skills");

                            j.IndexerProperty<int>("JobId").HasColumnName("job_id");

                            j.IndexerProperty<int>("SkillId").HasColumnName("skill_id");
                        });
            });

            modelBuilder.Entity<JobSeeker>(entity =>
            {
                entity.ToTable("Job_Seekers");

                entity.Property(e => e.JobSeekerId)
                    .ValueGeneratedNever()
                    .HasColumnName("job_seeker_id");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contact_number");

                entity.Property(e => e.Education)
                    .HasColumnType("text")
                    .HasColumnName("education");

                entity.Property(e => e.Experience)
                    .HasColumnType("text")
                    .HasColumnName("experience");

                entity.Property(e => e.LinkedinProfile)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("linkedin_profile");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.ProfilePicture)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("profile_picture");

                entity.Property(e => e.Resume)
                    .HasColumnType("text")
                    .HasColumnName("resume");

                entity.Property(e => e.Skills)
                    .HasColumnType("text")
                    .HasColumnName("skills");

                entity.HasOne(d => d.JobSeekerNavigation)
                    .WithOne(p => p.JobSeeker)
                    .HasForeignKey<JobSeeker>(d => d.JobSeekerId)
                    .HasConstraintName("FK__Job_Seeke__job_s__5441852A");

                entity.HasMany(d => d.SkillsNavigation)
                    .WithMany(p => p.JobSeekers)
                    .UsingEntity<Dictionary<string, object>>(
                        "JobSeekerSkill",
                        l => l.HasOne<Skill>().WithMany().HasForeignKey("SkillId").HasConstraintName("FK__Job_Seeke__skill__6C190EBB"),
                        r => r.HasOne<JobSeeker>().WithMany().HasForeignKey("JobSeekerId").HasConstraintName("FK__Job_Seeke__job_s__6B24EA82"),
                        j =>
                        {
                            j.HasKey("JobSeekerId", "SkillId").HasName("PK__Job_Seek__355E24BF3FF56534");

                            j.ToTable("Job_Seeker_Skills");

                            j.IndexerProperty<int>("JobSeekerId").HasColumnName("job_seeker_id");

                            j.IndexerProperty<int>("SkillId").HasColumnName("skill_id");
                        });
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasIndex(e => e.SkillName, "UQ__Skills__73C038ADCBB7269E")
                    .IsUnique();

                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.Property(e => e.SkillName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("skill_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__AB6E6164D44C1F4B")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UQ__Users__F3DBC57259BC97A6")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("full_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("user_type");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
