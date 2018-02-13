using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCServer.Models;

namespace UCServer.Models
{
    public class UserCity
    {
        public int Id { get; set; }
       
        public int UserId { get; set; }
  
        public int CityId { get; set; }

        //привязка к Users,Cities - навигационные свойства
        public ICollection<User> User { get; set; }
        public ICollection<City> City { get; set; }

}
}
