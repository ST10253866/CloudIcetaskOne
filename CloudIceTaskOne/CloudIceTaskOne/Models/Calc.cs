using System.ComponentModel.DataAnnotations;

namespace CloudIceTaskOne.Models
{
    public class Calc
    {
        [Display(Name = "Car Price")]
        public decimal CarPrice { get; set; }

        [Display(Name = "Number of Monthly payments you want to do")]
        public decimal MonthlyPayments { get; set; }

        [Display(Name = "Your instalments are :")]
        public decimal MonthInsalments { get; set; }

    }
}
