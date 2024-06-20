using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        private readonly bool isTestingEnvironment;
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options, bool isTestingEnvironment = false) : base(options) 
        {
            this.isTestingEnvironment = isTestingEnvironment;
        }
    }
}
