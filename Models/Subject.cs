using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineQuiz.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Question = new HashSet<Question>();
        }

        [Key]
        [Column("subjectId")]
        public int SubjectId { get; set; }
        [Column("subjectName")]
        [StringLength(20)]
        public string SubjectName { get; set; }
        [Column("active")]
        public bool? Active { get; set; }
        [Column("createdBy")]
        [StringLength(20)]
        public string CreatedBy { get; set; }
        [Column("createdDate", TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [InverseProperty("Subject")]
        public virtual ICollection<Question> Question { get; set; }
    }
}
