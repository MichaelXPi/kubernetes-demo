using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestApi1.Models;

namespace TestApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return new []
            {
                new Customer()
                {
                    Id = 10001,
                    Name = "Michael",
                    Location = Environment.MachineName
                },
                new Customer()
                {
                    Id = 10001,
                    Name = "Michael",
                    Location = Environment.MachineName
                },
                new Customer()
                {
                    Id = 10001,
                    Name = "Michael",
                    Location = Environment.MachineName
                }
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return new Customer()
            {
                Id = 10001,
                Name = "Michael",
                Location = Environment.MachineName
            };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
