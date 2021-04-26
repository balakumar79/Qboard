using Qboard.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Qboard.Models
{
    public partial class AnswerViewModel
    {
        public int Id { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        public bool? IsActive { get; set; }

        public virtual Questions Question { get; set; }
    }
}
