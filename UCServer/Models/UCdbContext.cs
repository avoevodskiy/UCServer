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
    public class UCdbContext:IUCdb
    {
        public string conStr;

        //public SqliteConnection conn;
        /*public DbSet<User> Users { get; set; } 
        public DbSet<City> Cities { get; set; }
        public DbSet<UserCity> UsersCities { get; set; }*/
        //конструктор
        public UCdbContext()
        {
            conStr = "Data Source=App_data\\Uc_db.db";
        }
        /*
        //конструктор
        public UCdbContext(DbContextOptions<UCdbContext> options) : base(options)

        {
            //SqliteConnection conn = new SqliteConnection();
           // conn.ConnectionString = "Data Source = App_Data\\UC_db.db";
            //conn.Open();

        }*/

        public IList<User> GetUsers ()
        {
            // IEnumerable<User> UList =
            SqliteConnection conn = new SqliteConnection(conStr);
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
            reader.Close();
            conn.Close();
            return Users; //flag;
        }

        public IList<City> GetCitiesOfUser(int id)
        {
            // IEnumerable<User> UList =
            SqliteConnection conn = new SqliteConnection(conStr);
            conn.Open();
            SqliteCommand command = new SqliteCommand(@"SELECT c.* FROM UsersCities as uc, cities as c where c.id=uc.cityid and uc.userid=@param", conn);
            command.Parameters.Add(new SqliteParameter("@param", SqliteType.Integer) { Value = id});
            //command.Parameters["@param"].Value = id;

            SqliteDataReader reader = command.ExecuteReader();//???

            IList<City> Cities = new List<City>();
            while (reader.Read())
            {
                var row = new City();
                row.Id = Int32.Parse(reader.GetString(0));
                row.Name = reader.GetString(1);
                Cities.Add(row);
                //IEnumerable<User> row = new IEnumerable<User>();
                //row=reader.Cast<User>();
            }


            bool flag = reader.HasRows;
            reader.Close();
            conn.Close();
            return Cities; //flag;
        }

        public string AddUser(User newUser)
        {
            SqliteConnection conn = new SqliteConnection(conStr);
            conn.Open();
            SqliteCommand command = new SqliteCommand(@"insert into users (name) values (@param)", conn);
            command.Parameters.Add(new SqliteParameter("@param", SqliteType.Text) { Value = newUser.Name});
            try
            {
               int insertResult=command.ExecuteNonQuery();
                if (insertResult >0)
                {
                    conn.Close();
                    return "New User succesfully added!";
                }
                else
                {
                    conn.Close();
                    return "New User not added!!!";
                }
                    
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }                        
        }


    }
}
