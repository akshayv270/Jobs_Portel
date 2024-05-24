using Jobs_Portel.BussinessEntity;
using Jobs_Portel.BussinessServices.Interface;
using Jobs_Portel.Common;
using Jobs_Portel.Repository;
using Jobs_Portel.Repository.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobs_Portel.BussinessServices.Concreate
{
    public class EmplyerServices : IEmplyerServices
    {
        private readonly IEmployeeRepository employeeRepo;
        public EmplyerServices()
        {
            employeeRepo = new EmployeeRepository();
        }
        public List<EmployerViewModel> GetEmployers()
        {
            var d = employeeRepo.GetEmployers();
            return d.ToviewModel();
        }

        public EmployerViewModel GetEmployers(int id)
        {
            var d = employeeRepo.GetEmployers(id);
            return d.ToviewModel();
        }
    }
}
