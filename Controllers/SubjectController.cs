using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineQuiz.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ILogger<SubjectController> _logger;

        public SubjectController(ILogger<SubjectController> logger)
        {
            _logger = logger;
        }

        // GET: api/<SubjectController>
        [HttpGet]
        public IEnumerable<Subject> Get()
        {
            using (CoreDbContext context = new CoreDbContext())
            {
                return context.Subject.ToList();
            }
        }

        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        public Subject Get(int id)
        {
            using (CoreDbContext context = new CoreDbContext())
            {
                return context.Subject.FirstOrDefault(c => c.SubjectId == id);
            }
        }

        // POST api/<SubjectController>
        [HttpPost]
        public void Post([FromBody] Subject subject)
        {
            using (CoreDbContext context = new CoreDbContext())
            {
                context.Subject.Add(subject);
                context.SaveChanges();
            }
        }

        // PUT api/<SubjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Subject subject)
        {
            using (CoreDbContext context = new CoreDbContext())
            {
                context.Subject.Update(subject);
                context.SaveChanges();
            }
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (CoreDbContext context = new CoreDbContext())
            {
                var subject = context.Subject.FirstOrDefault(x => x.SubjectId == id);

                context.Subject.Remove(subject);
                context.SaveChanges();
            }
        }
    }
}