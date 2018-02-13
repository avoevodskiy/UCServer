using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace UCServer.Models
{
    public class UCdbContext:DbContext
    {
        public DbSet<User> Users { get; set; } 
        public DbSet<City> Cities { get; set; }
        //public DbSet<UserCity> UsersCities { get; set; }
        //конструктор
        public UCdbContext(DbContextOptions<UCdbContext> options) : base(options)
        {
        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().ToTable("Cities");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<UserCity>().ToTable("UsersCities");
        }*/
    }
}
