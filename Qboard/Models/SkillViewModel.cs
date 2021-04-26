using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Qboard.Models
{
    public partial class SkillViewModel
    {
        public SkillViewModel()
        {
            Exam = new HashSet<ExamViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<ExamViewModel> Exam { get; set; }
    }
}
