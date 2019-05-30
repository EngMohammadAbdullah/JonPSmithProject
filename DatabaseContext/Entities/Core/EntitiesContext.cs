using System;
using System.Collections.Generic;
using System.Configuration;
//using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace DatabaseContext.Entities.Core
{

    public class EntitiesContext : DbContext
    {
        public EntitiesContext()
        {

        }

        public EntitiesContext(DbContextOptions<EntitiesContext> options)
            : base(options)
        {

        }

        //public EntitiesContext() 
        //{


        //    Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EntitiesContext>());
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // modelBuilder.Entity<Order>().HasQueryFilter(p => !p.SoftDeleted);

            //..Property(a => a.Items).IsConcurrencyToken()
            // .ValueGeneratedOnAddOrUpdate();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["dbTest"].ConnectionString);
            }


        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Employee> Employees { get; set; }


    }
}