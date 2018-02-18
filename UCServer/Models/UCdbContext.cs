using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UCServer.Models;


namespace UCServer.Models
{
    public class UCdbContext:DbContext
    {
        public DbSet<User> Users { get; set; } 
        public DbSet<City> Cities { get; set; }
        public DbSet<UserCity> UsersCities { get; set; }
        //конструктор
        public UCdbContext(DbContextOptions<UCdbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ДЛя уверенности простовляем соответсвия с таблицами базы
             modelBuilder.Entity<City>().ToTable("Cities");
             modelBuilder.Entity<User>().ToTable("Users");
             modelBuilder.Entity<UserCity>().ToTable("UsersCities");

            // Прописываем связь один-ко-многим между User и UserCity
            modelBuilder.Entity<UserCity>()
                .HasOne(pt => pt.User)
                .WithMany("UsersCities");
            // Прописываем связь один-ко-многим между City и UserCity 
            modelBuilder.Entity<UserCity>()
                .HasOne(pt => pt.City)
                .WithMany("UsersCities");

        }
    }
}
