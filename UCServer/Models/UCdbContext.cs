using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using UCServer.Models;
using Microsoft.Data.Sqlite;

namespace UCServer.Models
{
    public class UCdbContext:DbContext
    {
        //public SqliteConnection conn;
        /*public DbSet<User> Users { get; set; } 
        public DbSet<City> Cities { get; set; }
        public DbSet<UserCity> UsersCities { get; set; }*/
        //конструктор
        public UCdbContext(DbContextOptions<UCdbContext> options) : base(options)

        {
            //SqliteConnection conn = new SqliteConnection();
           // conn.ConnectionString = "Data Source = App_Data\\UC_db.db";
            //conn.Open();

        }

        public IList<User> GetUsers ()
        {
            // IEnumerable<User> UList =
            SqliteConnection conn = new SqliteConnection("Data Source = App_Data\\UC_db.db;");
            conn.Open();
            SqliteCommand command = new SqliteCommand("SELECT * FROM Users", conn);
            
            SqliteDataReader reader = command.ExecuteReader();//???

            IList<User> Users = new List<User>();
            while (reader.Read())
            {
                var row = new User();
                row.Id = Int32.Parse(reader.GetString(0));
                row.Name = reader.GetString(1);
                Users.Add(row);
                //IEnumerable<User> row = new IEnumerable<User>();
                //row=reader.Cast<User>();
            }

                
            bool flag = reader.HasRows;
            conn.Dispose();
            return Users; //flag;
        }

        public IList<City> GetCitiesOfUser(int id)
        {
            // IEnumerable<User> UList =
            SqliteConnection conn = new SqliteConnection("Data Source = App_Data\\UC_db.db;");
            conn.Open();
            SqliteCommand command = new SqliteCommand("SELECT * FROM Users", conn);

            SqliteDataReader reader = command.ExecuteReader();//???

            IList<User> Users = new List<User>();
            while (reader.Read())
            {
                var row = new User();
                row.Id = Int32.Parse(reader.GetString(0));
                row.Name = reader.GetString(1);
                Users.Add(row);
                //IEnumerable<User> row = new IEnumerable<User>();
                //row=reader.Cast<User>();
            }


            bool flag = reader.HasRows;
            conn.Dispose();
            return Users; //flag;
        }



        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
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

         }*/
    }
}
