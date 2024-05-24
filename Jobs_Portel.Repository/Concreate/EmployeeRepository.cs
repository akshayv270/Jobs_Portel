using Jobs_Portel.DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobs_Portel.Repository.Concreate
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Job_PortalContext context;

        public EmployeeRepository()
        {
            context = new Job_PortalContext();
        }
        public List<Employer> GetEmployers()
        {
            return context.Employers.ToList();
        }

        public Employer GetEmployers(int id)
        {
            return context.Employers.Find(id);
        }
    }
}
