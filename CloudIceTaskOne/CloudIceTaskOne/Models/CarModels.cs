using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudIceTaskOne.Models
{
    public class CarModels
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Car Type")]
        [Required]
        public string? CarType { get; set; }
        
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Car Models")]
        [Required]
        public string? CarModel { get; set; }
        
        
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        
        
        


    }
}
