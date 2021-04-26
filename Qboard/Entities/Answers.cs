using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Qboard.Entities
{
    public partial class Answers
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Name { get; set; }
        public bool IsCorrect { get; set; }
        public bool? IsActive { get; set; }
    }
}
