using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobs_Portel.BussinessEntity
{
    public class EmployerViewModel
    {
        public int EmployerId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? CompanyWebsite { get; set; }
        public string? Location { get; set; }
        public string? ContactNumber { get; set; }
        public string? Industry { get; set; }

    }
}
