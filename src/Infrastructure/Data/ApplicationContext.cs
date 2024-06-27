using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Show> Shows { get; set; }



        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator<UserType>("UserRole")
                    .HasValue<Client>(UserType.Client)
                    .HasValue<Admin>(UserType.Admin);

            base.OnModelCreating(modelBuilder);

        }


    }
}
