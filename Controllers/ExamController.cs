using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineQuiz.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineQuiz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamController : Controller
    {

        private readonly ILogger<ExamController> _logger;
        private readonly CoreDbContext _context;

        public ExamController(ILogger<ExamController> logger, CoreDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IEnumerable<Question> GetAll(int id)
        {
            try
            {
                var questions = _context.Question.Where(x => x.SubjectId == id);

                if (questions != null)
                {
                    return questions.ToList();
                }

                return null;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}