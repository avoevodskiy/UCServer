using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using UCServer.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
//using System.ComponentModel.DataAnnotations.Schema;


namespace UCServer.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //привязка к UserCity - навигационное свойство
        private ICollection<UserCity> UsersCities { get;  } = new List<UserCity>();
        [NotMapped]
        public IEnumerable<string> Cities=> UsersCities.Select(e => e.City.Name);//получаем названия городов

        

    }

}
