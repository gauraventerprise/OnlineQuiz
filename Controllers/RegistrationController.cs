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
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly CoreDbContext _context;

        public RegistrationController(ILogger<RegistrationController> logger, CoreDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Candidate> GetAll()
        {
            try
            {
                return _context.Candidate.ToList();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public JsonResult Post([FromBody] Candidate candidate)
        {
            try
            {
                candidate.Active = true;
                candidate.CreatedBy = candidate.Username;
                candidate.CreatedDate = DateTime.Now;

                _context.Candidate.Add(candidate);
                _context.SaveChanges();

                return new JsonResult("Candidate Added Successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult Put([FromBody] Candidate candidateNew)
        {
            try
            {
                var candidateOld = _context.Candidate.FirstOrDefault(x => x.CandidateId == candidateNew.CandidateId);

                if (candidateOld != null)
                {
                    candidateOld.Username = candidateNew.Username;
                    candidateOld.Password = candidateNew.Password;
                    candidateOld.FirstName = candidateNew.FirstName;
                    candidateOld.LastName = candidateNew.LastName;
                    candidateOld.Address = candidateNew.Address;
                    candidateOld.Email = candidateNew.Email;
                    candidateOld.Mobile = candidateNew.Mobile;
                    candidateOld.Birthday = candidateNew.Birthday;
                    candidateOld.Gender = candidateNew.Gender;
                    candidateOld.Photo = candidateNew.Photo;

                    candidateOld.Active = true;
                    candidateOld.ModifiedBy = candidateNew.Username;
                    candidateOld.ModifiedDate = DateTime.Now;

                    _context.Candidate.Update(candidateOld);
                    _context.SaveChanges();

                    return new JsonResult("Candidate Updated Successfully");
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
                var candidate = _context.Candidate.FirstOrDefault(x => x.CandidateId == id);

                if (candidate != null)
                {
                    _context.Candidate.Remove(candidate);
                    _context.SaveChanges();

                    return new JsonResult("Candidate Deleted Successfully");
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