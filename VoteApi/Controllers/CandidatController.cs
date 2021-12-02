using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VoteApi.DTO;
using VoteApi.Entities;
using VoteApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VoteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatController : ControllerBase
    {
       
        private readonly ICandidateServis _service;
        
        public CandidatController(ICandidateServis service)
        {
            _service = service;
        }

        // GET: api/<CandidatController>
        [HttpGet]
        public ActionResult<IEnumerable<Candidate>> Get()
        {
            var result = _service.getList();
            return Ok(result); 
        }

        // GET api/<CandidatController>/5
        [HttpGet("{id}")]
        public ActionResult<Candidate> Get(int id)
        {
            var candidate = _service.GetById(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return Ok(candidate);
        }

        // POST api/<CandidatController>
        [HttpPost]
        public ActionResult Post([FromBody] CandidateInsertDTO dto)
        {
            var id = _service.addNew(dto);

            return Created($"/api/[controller]/{id}", null);
        }
    }
}
