using Jobs_Portel.BussinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobs_Portel.BussinessServices.Interface
{
    public interface IEmplyerServices 
    {
        List<EmployerViewModel> GetEmployers();

        EmployerViewModel GetEmployers(int id);
    }
}
