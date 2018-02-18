using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCServer.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace UCServer.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        //привязка к UserCity - навигационное свойство
        private ICollection<UserCity> UsersCities { get;  } = new List<UserCity>();
        [NotMapped]
        public IEnumerable<User> Users=> UsersCities.Select(e => e.User);//получаем пользователей

    }


}
