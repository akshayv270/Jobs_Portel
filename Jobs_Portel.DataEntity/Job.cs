using System;
using System.Collections.Generic;

namespace Jobs_Portel.DataEntity
{
    public partial class Job
    {
        public Job()
        {
            Skills = new HashSet<Skill>();
        }

        public int JobId { get; set; }
        public int? EmployerId { get; set; }
        public string JobTitle { get; set; } = null!;
        public string JobDescription { get; set; } = null!;
        public string JobRequirements { get; set; } = null!;
        public string JobType { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string? SalaryRange { get; set; }
        public DateTime? PostedAt { get; set; }
        public DateTime? ApplicationDeadline { get; set; }

        public virtual Employer? Employer { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
    }
}
