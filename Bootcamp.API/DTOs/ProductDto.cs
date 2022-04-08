using Bootcamp.API.Models;

namespace Bootcamp.API.DTOs
{
    public class ProductDto
    {
        // Burada propertyler Product entitysinden alındı ama Stock propertysini dış dünyaya açmak istemediğim için onu kaldırdım.
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal? Price { get; set; }

        // Normalde parametresiz default ctor vardır ama parametreli ctor yapınca kalkar. O yüzden dursun istiyorsak bir tane parametresiz ctor yazıyoruz.
        public ProductDto()
        {

        }

        public ProductDto(Product product)
        {
            Id= product.Id;
            Name= product.Name;
            Price = product.Price.Value;
        }



    }
}
