using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Qboard.Entities
{
    public partial class Exams
    {
        public int Id { get; set; }
        public string ExamName { get; set; }
        public int? Skill { get; set; }
        public int? ContempararyLevel { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public bool? IsActive { get; set; }

        public virtual ContempararyLevels ContempararyLevelNavigation { get; set; }
        public virtual Skills SkillNavigation { get; set; }
    }
}
