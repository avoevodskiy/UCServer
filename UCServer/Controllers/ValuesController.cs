using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UCServer.Models;

namespace UCServer.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly UCdbContext _context; //

        //констурктор в котором получаем контекст базы 
        public ValuesController(UCdbContext context)
        {
            _context = context;

        }

        // GET api/values
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "UserReturn")]
        public IActionResult Get(int id)
        {
            //return "value";
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return null;
            }
            return new ObjectResult(user);

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
        public IActionResult Create([FromBody] User newuser)
        {
            if (newuser == null)
            {
                return BadRequest();
            }
            _context.Users.Add(newuser);
            _context.SaveChanges();
            return CreatedAtRoute("UserReturn", new { id = newuser.Id });
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
