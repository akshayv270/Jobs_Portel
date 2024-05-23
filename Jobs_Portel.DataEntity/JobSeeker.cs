using System;
using System.Collections.Generic;

namespace Jobs_Portel.DataEntity
{
    public partial class JobSeeker
    {
        public JobSeeker()
        {
            SkillsNavigation = new HashSet<Skill>();
        }

        public int JobSeekerId { get; set; }
        public string? Resume { get; set; }
        public string? Skills { get; set; }
        public string? Experience { get; set; }
        public string? Education { get; set; }
        public string? Location { get; set; }
        public string? ContactNumber { get; set; }
        public string? ProfilePicture { get; set; }
        public string? LinkedinProfile { get; set; }

        public virtual User JobSeekerNavigation { get; set; } = null!;

        public virtual ICollection<Skill> SkillsNavigation { get; set; }
    }
}
