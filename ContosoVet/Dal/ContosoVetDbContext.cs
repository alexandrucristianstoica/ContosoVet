using ContosoVet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Dal
{
    public class ContosoVetDbContext : DbContext
    {
        public ContosoVetDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Admin> Admins { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<>()
        //        .HasKey(scp => new {  });
        //    modelBuilder.Entity<ShoppingCartProduct>()
        //        .HasOne(scp => scp.ShoppingCart)
        //        .WithMany(p => p.ShoppingCartProducts)
        //        .HasForeignKey(scp => scp.ShoppingCartId);
        //    modelBuilder.Entity<ShoppingCartProduct>()
        //        .HasOne(scp => scp.Product)
        //        .WithMany(sc => sc.SchoppingCartProducts)
        //        .HasForeignKey(scp => scp.ProductId);
        //}

    }
}
