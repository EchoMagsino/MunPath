    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Tools;
    using MunPath.Domain.Entities;
    using System;
    using Microsoft.EntityFrameworkCore.Design;

    namespace MunPath.Infrastructure
    {
        public class ApplicationDbContext: DbContext
        {
            
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
            {
                
            }

            public DbSet<Student> Students {get; set;} = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example constraints for Student entity
            modelBuilder.Entity<Student>(entity =>
            {
                // Primary key
                entity.HasKey(s => s.Id);

                // Unique constraint on Email
                entity.HasIndex(s => s.Email).IsUnique();

                // Required fields
                entity.Property(s => s.FirstName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(s => s.LastName)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(s => s.Email)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(s => s.Password)
                      .IsRequired()
                      .HasMaxLength(100);

                

                // Default value
                // entity.Property(s => s.CreatedAt)
                //       .HasDefaultValueSql("CURRENT_TIMESTAMP");

                // Relationships (if you have related entities)
                // entity.HasOne(s => s.Course)
                //       .WithMany(c => c.Students)
                //       .HasForeignKey(s => s.CourseId);
            });
        }
        }
    }