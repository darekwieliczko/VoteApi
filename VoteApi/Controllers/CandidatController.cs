using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VoteApi.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VoteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatController : ControllerBase
    {
        // GET: api/<CandidatController>
        [HttpGet]
        public ActionResult<IEnumerable<Candidate>> Get()
        {
            var result =  new List<Candidate>();
            
            return Ok(result); // new string[] { "value1", "value2" };
        }

        // GET api/<CandidatController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CandidatController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CandidatController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CandidatController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
