using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCServer.Models
{
    public interface IUCdb
    {
        //bool GetData(string sql);
        IList<User> GetUsers();
        IList<City> GetCitiesOfUser(int id);
        string AddUser(User newUser);

        //string ExecuteScalar(string sql);
    }
}
