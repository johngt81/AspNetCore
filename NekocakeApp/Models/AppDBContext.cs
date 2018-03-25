using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NekocakeApp.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            :base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pie>()
                .ToTable("Pie", schema: "dbo");

            modelBuilder.Entity<Pie>()  
                .Property(b => b.PieId)
                .HasColumnName("Id");

            modelBuilder.Entity<Feedback>()
           .ToTable("Feedback", schema: "dbo");

        }
    }
}
