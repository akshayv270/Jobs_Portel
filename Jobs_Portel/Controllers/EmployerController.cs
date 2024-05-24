using Jobs_Portel.BussinessServices.Interface;
using Jobs_Portel.BussinessServices.Concreate;

using Microsoft.AspNetCore.Mvc;

namespace Jobs_Portel.Controllers
{
    public class EmployerController : Controller
    {
        private readonly IEmplyerServices emplyerServices;
        public EmployerController()
        {
            emplyerServices = new EmplyerServices();
        }
        public IActionResult Index()
        {
            return View(emplyerServices.GetEmployers());
        }
    }
}
