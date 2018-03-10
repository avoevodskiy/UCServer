﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UCServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;
using System.Data.SqlClient;

namespace UCServer.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IUCdb _context; //

        //констурктор в котором получаем контекст базы 
        public ValuesController(IUCdb context)
        {
            _context = context;

        }

        // GET api/values
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
           return _context.GetUsers();
        }
        [HttpGet("{id}")]
        public IEnumerable<City> GetCities(int id)
        {
            return _context.GetCitiesOfUser(id);
        }
        // GET api/user/5
        /* [HttpGet("{id}")]
         public IActionResult Get(int id)
         {
             /*var users = _context.Users.Include("UsersCities.City").ToList();
             User user = users.Find(x => x.Id == id);  //_context.Users.Find(id);

             if (user == null)
             {
                 return NotFound();
             }



             var citi3 = user.Cities;

             return new ObjectResult(citi3);

         }

         // POST api/values
         /* [HttpPost]
         public IEnumerable<User> Post([FromBody]string value)
         {
            // if (value == "Users")  
             //{
                 return _context.Users.ToList();
             //}
         }*/

         [HttpPost]
         public string Create([FromBody] User newuser)
         {
             if (newuser == null)
             {
                return "BadRequest";//BadRequest();
             }
             string result = _context.AddUser(newuser);

            //int id = newuser.Id;
            //return new ObjectResult(newuser);
            return result;
         }

        /*
         // PUT api/values/5
         [HttpPut("{id}")]
         public void Put(int id, [FromBody]string value)
         {
         }

         // DELETE api/values/5
         [HttpDelete("{id}")]
         public void Delete(int id)
         {
         }*/
    }
}
