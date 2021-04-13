using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ILogger<SubjectController> _logger;
        private readonly CoreDbContext _context;
        public SubjectController(ILogger<SubjectController> logger, CoreDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Subject> Get()
        {
            try
            {
                return _context.Subject.ToList();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public JsonResult Post([FromBody] Subject subject)
        {
            try
            {
                subject.Active = true;
                subject.CreatedBy = "";
                subject.CreatedDate = DateTime.Now;

                _context.Subject.Add(subject);
                _context.SaveChanges();

                return new JsonResult("Subject Added Successfully");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public JsonResult Put([FromBody] Subject subjectNew)
        {
            try
            {
                var subjectOld = _context.Subject.FirstOrDefault(x => x.SubjectId == subjectNew.SubjectId);

                if (subjectOld != null)
                {
                    subjectOld.SubjectName = subjectNew.SubjectName;
                    subjectOld.Active = true;

                    _context.Subject.Update(subjectOld);
                    _context.SaveChanges();

                    return new JsonResult("Subject Updated Successfully");
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
                var subject = _context.Subject.FirstOrDefault(x => x.SubjectId == id);

                if (subject != null)
                {
                    _context.Subject.Remove(subject);
                    _context.SaveChanges();

                    return new JsonResult("Subject Deleted Successfully");
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