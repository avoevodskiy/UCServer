using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UCServer.Models;

namespace UCServer.Models
{
    public class UserCity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CityId { get; set; }

        //привязка к Users,Cities - навигационные свойства
        //public User User { get; set; } 
        //public City City { get; set; } 

    }
}
