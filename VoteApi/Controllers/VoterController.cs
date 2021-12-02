using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VoteApi.DTO;
using VoteApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VoteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoterController : ControllerBase
    {
        private readonly IVoterService _voteService;

        public VoterController(IVoterService voteService)
        {
            _voteService = voteService;
        }

        // GET: api/<VoterController>
        [HttpGet]
        public ActionResult<IEnumerable<VoterDTO>> Get()
        {
            var result = _voteService.getList();
            
            return Ok(result);
        }

        // GET api/<VoterController>/5
        [HttpGet("{id}")]
        public ActionResult<VoterDTO> Get(int id)
        {
            var result = _voteService.GetById(id);
            
            return Ok(result);
        }

        // POST api/<VoterController>
        [HttpPost]
        public ActionResult Post([FromBody] VoterInsertDTO value)
        {
            int id = _voteService.addNew(value);

            return Created($"api/[controller]/{id}", null);
        }

        // PUT api/<VoterController>/5/3
        [HttpPut("{idCandidate}/{idVoter}")]
        public ActionResult<int> Put(int idCandidate, int idVoter)
        {
            if (_voteService.canVote(idVoter))
            {
                var votes = _voteService.addVote(idCandidate);
                _voteService.setVoted(idVoter);
                return Ok(votes);
            }
            return BadRequest(idVoter);
        }
    }
}
