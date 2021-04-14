using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineQuiz.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineQuiz.Controllers
{
    public class ExamController : Controller
    {

        private readonly ILogger<ExamController> _logger;
        private readonly CoreDbContext _context;

        public ExamController(ILogger<ExamController> logger, CoreDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Question> GetQuestionsBySubject(int subjectId)
        {
            try
            {
                var questions = _context.Question.Where(x => x.SubjectId == subjectId);

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