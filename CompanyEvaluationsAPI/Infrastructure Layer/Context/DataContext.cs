using CompanyEvaluationsAPI.Infrastructure.Models;
using CompanyEvaluationsAPI.Infrastructure_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace CompanyEvaluationsAPI.Infrastructure.Context
{
    public class DataContext : DbContext
    {
        
            public DbSet<Department> Departments { get; set; }
            public DbSet<Employee> Employees { get; set; }
            public DbSet<Rating> Ratings { get; set; }

            public DataContext(DbContextOptions<DataContext> options)
                : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Rater)
                .WithMany(e => e.GivenRatings)
                .HasForeignKey(r => r.RaterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Ratee)
                .WithMany(e => e.ReceivedRatings)
                .HasForeignKey(r => r.RateeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                   .HasOne(e => e.Department)
                   .WithMany(d => d.Employees)
                   .HasForeignKey(e => e.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Name = "Marketing"
                }, new Department
                {
                    Id = 2,
                    Name = "Development"
                });


            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name= "Mohamed",
                    DepartmentId= 1
                }, new Employee
                {
                    Id = 2,
                    Name = "Saied",
                    DepartmentId = 1
                }, new Employee
                {
                    Id = 3,
                    Name = "Hassan",
                    DepartmentId = 2
                }, new Employee
                {
                    Id = 4,
                    Name = "aly",
                    DepartmentId = 2
                });

            modelBuilder.Entity<Rating>().HasData(
                new Rating
                {
                    Id = 1,
                    RaterId = 1,
                    RateeId = 2,
                    Score = 1,
                    
                }, new Rating
                {
                    Id = 2,
                    RaterId = 1,
                    RateeId = 3,
                    Score = 2,

                }, new Rating
                {
                    Id = 3,
                    RaterId = 3,
                    RateeId = 1,
                    Score = 4,

                }, new Rating
                {
                    Id = 4,
                    RaterId = 4,
                    RateeId = 2,
                    Score =3
                });




        }


        }

    }

