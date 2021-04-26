using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Qboard.Entities
{
    public partial class ContempararyLevels
    {
        public ContempararyLevels()
        {
            Exams = new HashSet<Exams>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Exams> Exams { get; set; }
    }
}
