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
        }
    }