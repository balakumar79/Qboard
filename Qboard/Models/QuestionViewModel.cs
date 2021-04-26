using Qboard.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Qboard.Models
{
    public class QuestionViewModel
    {
        public QuestionViewModel()
        {
            Answers = new HashSet<Answers>();
        }

        public int Id { get; set; }

        [Required]
        public string Question { get; set; }
        public int ExamId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public bool? IsActove { get; set; }

        
        public ICollection<Answers> Answers { get; set; }
        public  List<Exams> Exams { get; set; }
        public List<Skills> Skills { get; set; }
        public List<ContempararyLevels> ContempararyLevels { get; set; }
        
    }
}
