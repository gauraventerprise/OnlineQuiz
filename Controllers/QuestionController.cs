using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineQuiz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly ILogger<QuestionController> _logger;
        private readonly CoreDbContext _context;

        public QuestionController(ILogger<QuestionController> logger, CoreDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Question> GetAll()
        {
            try
            {
                return _context.Question.ToList();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public JsonResult Post([FromBody] Question question)
        {
            try
            {
                question.Active = true;
                question.CreatedBy = ""; // need to add username
                question.CreatedDate = DateTime.Now;

                _context.Question.Add(question);
                _context.SaveChanges();

                return new JsonResult("Question Added Successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult Put([FromBody] Question questionNew)
        {
            try
            {
                var questionOld = _context.Question.FirstOrDefault(x => x.QuestionId == questionNew.QuestionId);

                if (questionOld != null)
                {
                    questionOld.Question1 = questionNew.Question1;
                    questionOld.Option1 = questionNew.Option1;
                    questionOld.Option2 = questionNew.Option2;
                    questionOld.Option3 = questionNew.Option3;
                    questionOld.Option4 = questionNew.Option4;
                    questionOld.Answer = questionNew.Answer;
                    questionOld.Complexity = questionNew.Complexity;

                    questionOld.Active = true;

                    _context.Question.Update(questionOld);
                    _context.SaveChanges();

                    return new JsonResult("Question Updated Successfully");
                }

                return new JsonResult("Please enter valid id");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                var question = _context.Question.FirstOrDefault(x => x.QuestionId == id);

                if (question != null)
                {
                    _context.Question.Remove(question);
                    _context.SaveChanges();

                    return new JsonResult("Question Deleted Successfully");
                }

                return new JsonResult("Please enter valid id");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}