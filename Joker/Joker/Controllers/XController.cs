using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Joker.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class XController : ControllerBase
    {
        // GET: api/X
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/X/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "{value: '1'}";
        }

        // POST: api/X
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/X/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}