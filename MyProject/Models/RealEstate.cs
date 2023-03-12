using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class RealEstate
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Тип недвижимости")]
        public string PropertyType { get; set; }

        [Required]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
    }
}
