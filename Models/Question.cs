using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineQuiz.Models
{
    public partial class Question
    {
        [Key]
        [Column("questionId")]
        public int QuestionId { get; set; }

        [Column("subjectId")]
        public int? SubjectId { get; set; }

        [Column("question")]
        public string Question1 { get; set; }

        [Column("option1")]
        public string Option1 { get; set; }

        [Column("option2")]
        public string Option2 { get; set; }

        [Column("option3")]
        public string Option3 { get; set; }

        [Column("option4")]
        public string Option4 { get; set; }

        [Column("answer")]
        public string Answer { get; set; }

        [Column("complexity")]
        [StringLength(20)]
        public string Complexity { get; set; }

        [Column("active")]
        public bool? Active { get; set; }

        [Column("createdBy")]
        [StringLength(20)]
        public string CreatedBy { get; set; }

        [Column("createdDate", TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }


        [ForeignKey(nameof(SubjectId))]
        [InverseProperty("Question")]
        public virtual Subject Subject { get; set; }
    }
}
