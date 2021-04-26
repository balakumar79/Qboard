using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Qboard.Entities
{
    public partial class Questions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExamId { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public bool? IsActove { get; set; }
    }
}
