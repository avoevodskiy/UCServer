using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCServer.Models
{
    public class User
    {
        public int Id { get; set; }
     
        public string Name { get; set; }
        //привязка к UserCity - навигационное свойство
        public ICollection<UserCity> UsersCities { get; set; }
    }
}
