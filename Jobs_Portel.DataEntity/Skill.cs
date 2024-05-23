using System;
using System.Collections.Generic;

namespace Jobs_Portel.DataEntity
{
    public partial class Skill
    {
        public Skill()
        {
            JobSeekers = new HashSet<JobSeeker>();
            Jobs = new HashSet<Job>();
        }

        public int SkillId { get; set; }
        public string SkillName { get; set; } = null!;

        public virtual ICollection<JobSeeker> JobSeekers { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
