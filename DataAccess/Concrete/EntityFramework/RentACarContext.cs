using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentACarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-1NLBACI\SQLSERVER;Initial Catalog=RentACarProject;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(c=>c.UserId);

            modelBuilder.Entity<OperationClaim>().ToTable("OperationClaims");
            modelBuilder.Entity<OperationClaim>().Property(o => o.Id).HasColumnName("Id");
            modelBuilder.Entity<OperationClaim>().Property(o => o.Name).HasColumnName("Name");

            modelBuilder.Entity<UserOperationClaim>().ToTable("UserOperationClaims");
            modelBuilder.Entity<UserOperationClaim>().Property(o => o.Id).HasColumnName("Id");
            modelBuilder.Entity<UserOperationClaim>().Property(o => o.UserId).HasColumnName("UserId");
            modelBuilder.Entity<UserOperationClaim>().Property(o => o.OperationClaimId).HasColumnName("OperationClaimId");

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().Property(o => o.Id).HasColumnName("UserId");
            modelBuilder.Entity<User>().Property(o => o.FirstName).HasColumnName("FirstName");
            modelBuilder.Entity<User>().Property(o => o.LastName).HasColumnName("LastName");
            modelBuilder.Entity<User>().Property(o => o.Email).HasColumnName("Email");
            modelBuilder.Entity<User>().Property(o => o.Status).HasColumnName("Status");
            modelBuilder.Entity<User>().Property(o => o.PasswordHash).HasColumnName("PasswordHash");
            modelBuilder.Entity<User>().Property(o => o.PasswordSalt).HasColumnName("PasswordSalt");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
    }
}
