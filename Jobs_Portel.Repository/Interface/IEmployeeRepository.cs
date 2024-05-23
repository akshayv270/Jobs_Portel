using Jobs_Portel.DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobs_Portel.Repository
{
    public interface IEmployeeRepository
    {
        List<Employer> GetEmployers();
        Employer GetEmployers(int id);

    }
}
