using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace ContractMonthlyClaimSystem.Models
{
    //ChatGPT consulted to fix structure only.
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<ClaimHistory> ClaimHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Claim>().ToTable("Claims");
            modelBuilder.Entity<ClaimHistory>().ToTable("ClaimHistories");

            modelBuilder.Entity<Claim>()
                .HasOne(c => c.Lecturer)
                .WithMany()
                .HasForeignKey(c => c.LecturerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClaimHistory>()
                .HasOne(h => h.Claim)
                .WithMany()
                .HasForeignKey(h => h.ClaimId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ClaimHistory>()
                .HasOne(h => h.UpdatedBy)
                .WithMany()
                .HasForeignKey(h => h.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);

            //seed demo users (helpful for local testing)
            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, FullNames = "Demo Lecturer", Surname = "One", Email = "lecturer@example.com", Role = "Lecturer", Gender = "N/A", Password = "password", Date = DateTime.Now },
                new User { UserID = 2, FullNames = "Demo Coordinator", Surname = "One", Email = "coord@example.com", Role = "Coordinator", Gender = "N/A", Password = "password", Date = DateTime.Now },
                new User { UserID = 3, FullNames = "Demo Manager", Surname = "One", Email = "manager@example.com", Role = "Manager", Gender = "N/A", Password = "password", Date = DateTime.Now },
                new User { UserID = 4, FullNames = "Demo HR", Surname = "One", Email = "hr@example.com", Role = "HR", Gender = "N/A", Password = "password", Date = DateTime.Now }
            );

            modelBuilder.Entity<Claim>().HasData(
                new Claim { ClaimID = 1, LecturerID = 1, LecturerName = "Demo Lecturer", ModuleName = "Programming 1A", FacultyName = "Science & Technology", NumberOfSessions = 1, NumberOfHours = 3, HourlyRate = 250m, TotalAmount = 750m, SupportingDocuments = "doc1.pdf", ClaimStatus = "Pending", CreatingDate = DateTime.Now.AddDays(-2) },
                new Claim { ClaimID = 2, LecturerID = 1, LecturerName = "Demo Lecturer", ModuleName = "Databases", FacultyName = "Science & Technology", NumberOfSessions = 2, NumberOfHours = 2, HourlyRate = 300m, TotalAmount = 1200m, SupportingDocuments = "doc2.pdf", ClaimStatus = "Coordinator Approved", CreatingDate = DateTime.Now.AddDays(-7) }
            );
        }
    }
}
