using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineQuiz.Models
{
    public partial class Candidate
    {
        [Key]
        [Column("candidateId")]
        public int CandidateId { get; set; }

        [Column("username")]
        [StringLength(20)]
        public string Username { get; set; }

        [Column("password")]
        [StringLength(20)]
        public string Password { get; set; }
        
        [Column("firstName")]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Column("lastName")]
        [StringLength(20)]
        public string LastName { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("mobile")]
        [StringLength(10)]
        public string Mobile { get; set; }
        [Column("birthday", TypeName = "date")]
        public DateTime? Birthday { get; set; }
        [Column("gender")]
        [StringLength(10)]
        public string Gender { get; set; }
        [Column("photo")]
        [MaxLength(1)]
        public byte[] Photo { get; set; }
        [Column("active")]
        public bool? Active { get; set; }
        [Column("createdBy")]
        [StringLength(20)]
        public string CreatedBy { get; set; }
        [Column("createdDate", TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [Column("modifiedBy")]
        [StringLength(20)]
        public string ModifiedBy { get; set; }
        [Column("modifiedDate", TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
    }
}
