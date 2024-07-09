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

            // Relación de uno a muchos entre Movie y Show
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Shows)
                .WithOne()
                .HasForeignKey(s => s.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación entre Client y Show
            modelBuilder.Entity<Client>()
                .HasMany(c => c.ShowsBuyed)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>( //tabla que mantiene la relacion entre un cliente y distintas finciones mediante ids
                    "ClientShow",
                    j => j.HasOne<Show>().WithMany().HasForeignKey("ShowId"),
                    j => j.HasOne<Client>().WithMany().HasForeignKey("ClientId"));



            base.OnModelCreating(modelBuilder);

        }


    }
}
