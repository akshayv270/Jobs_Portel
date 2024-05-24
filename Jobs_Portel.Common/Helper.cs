using Jobs_Portel.BussinessEntity;
using Jobs_Portel.DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobs_Portel.Common
{
    static public class Helper
    {
          public static EmployerViewModel ToviewModel(this Employer employer)
        {
            return new EmployerViewModel
            {
                EmployerId = employer.EmployerId,
                CompanyName = employer.CompanyName,
                CompanyWebsite = employer.CompanyWebsite,
                Location = employer.Location,
                ContactNumber = employer.ContactNumber,
                Industry = employer.Industry
            };
        }
        public static List<EmployerViewModel> ToviewModel(this List<Employer> employers)
        {
            return employers.Select(x => ToviewModel(x)).ToList();
        }
    }
}
