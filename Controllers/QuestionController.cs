using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineQuiz.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineQuiz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly ILogger<QuestionController> _logger;

        public QuestionController(ILogger<QuestionController> logger)
        {
            _logger = logger;
        }

        // GET: api/<QuestionController>
        [HttpGet]
        public IEnumerable<Question> GetAll()
        {
            using (CoreDbContext context = new CoreDbContext())
            {
                return context.Question.ToList();
            }
        }

        // GET api/<QuestionController>/5
        [HttpGet]
        public Question Get(int id)
        {
            using (CoreDbContext context = new CoreDbContext())
            {
                return context.Question.FirstOrDefault(c => c.QuestionId == id);
            }
        }

        // POST api/<QuestionController>
        [HttpPost]
        public void Post([FromBody] Question question)
        {
            using (CoreDbContext context = new CoreDbContext())
            {
                context.Question.Add(question);
                context.SaveChanges();
            }
        }

        // PUT api/<QuestionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Question question)
        {
            using (CoreDbContext context = new CoreDbContext())
            {
                context.Question.Update(question);
                context.SaveChanges();
            }
        }

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (CoreDbContext context = new CoreDbContext())
            {
                var question = context.Question.FirstOrDefault(x => x.QuestionId == id);

                context.Question.Remove(question);
                context.SaveChanges();
            }
        }
    }
}