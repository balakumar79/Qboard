using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Qboard.Models
{
    public partial class ExamViewModel
    {
        public int Id { get; set; }
        public string ExamName { get; set; }
        public int? Skill { get; set; }
        public int? ContempararyLevel { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public bool? IsActive { get; set; }

        public virtual ContempararyLevelViewModel ContempararyLevelNavigation { get; set; }
        public virtual SkillViewModel SkillNavigation { get; set; }
    }
}
