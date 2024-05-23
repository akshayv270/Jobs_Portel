using System;
using System.Collections.Generic;

namespace Jobs_Portel.DataEntity
{
    public partial class Employer
    {
        public Employer()
        {
            Jobs = new HashSet<Job>();
        }

        public int EmployerId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? CompanyWebsite { get; set; }
        public string? Location { get; set; }
        public string? ContactNumber { get; set; }
        public string? Industry { get; set; }
      //  public string? CompanyLogo { get; set; }

        public virtual User EmployerNavigation { get; set; } = null!;
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
