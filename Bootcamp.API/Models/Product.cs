using System.ComponentModel.DataAnnotations;

namespace Bootcamp.API.Models
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(10, ErrorMessage = "Name alanı 10 karakterden büyük olamaz.")]
        [Required(ErrorMessage = "Name alanı boş olamaz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price alanı boş olamaz.")]
        public decimal? Price { get; set; }
        [Url]
        [Range(10,100,ErrorMessage ="Stok alanı 10 ile 100 arasında bir değer olmalıdır.")]
        [Required(ErrorMessage = "Stock alanı boş olamaz.")]
        public int? Stock { get; set; }
    }
}
