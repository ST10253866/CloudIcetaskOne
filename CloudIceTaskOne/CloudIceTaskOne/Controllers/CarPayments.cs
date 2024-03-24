using CloudIceTaskOne.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloudIceTaskOne.Controllers
{
    public class CarPayments : Controller
    {
        public IActionResult Index()
        {
            return View(new Calc());
        }
        [HttpPost]
        
        public ActionResult Index(Calc calc )
        {
            if ( calc.MonthlyPayments > 0) 
            {
                calc.MonthInsalments = (calc.CarPrice * 2) / calc.MonthlyPayments;
            }
            return View(calc);
          
        }
    }
}
