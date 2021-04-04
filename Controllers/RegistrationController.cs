using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineQuiz.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;
        
        public RegistrationController(ILogger<RegistrationController> logger)
        {
            _logger = logger;
        }

        // GET: api/<RegistrationController>
        [HttpGet]
        [Route("GetAllCandidates")]
        public IEnumerable<Candidate> GetAll()
        {
            using (CoreDbContext context = new CoreDbContext())
            {
                return context.Candidate.ToList();
            }
        }

        // GET: api/<RegistrationController>/5
        [HttpGet("{id}")]
        [Route("GetCandidateById")]
        public Candidate Get(int id)
        {
            using (CoreDbContext entities = new CoreDbContext())
            {
                return entities.Candidate.FirstOrDefault(c => c.CandidateId == id);
            }
        }

        // POST api/<RegistrationController>
        [HttpPost]
        [Route("AddCandidate")]
        public void Post([FromBody] Candidate value)
        {
        }

        // PUT api/<RegistrationController>/5
        [HttpPut("{id}")]
        [Route("UpdateCandidate")]
        public void Put(int id, [FromBody] Candidate candidate)
        {
            using (CoreDbContext entities = new CoreDbContext())
            {
                entities.Candidate.Update(candidate);
                entities.SaveChanges();
            }
        }

        // DELETE api/<RegistrationController>/5
        [HttpDelete("{id}")]
        [Route("DeleteCandidate")]
        public void Delete(int id)
        {
            using (CoreDbContext entities = new CoreDbContext())
            {
                var candidate = entities.Candidate.FirstOrDefault(x => x.CandidateId == id);

                entities.Candidate.Remove(candidate);
                entities.SaveChanges();
            }
        }
    }
}