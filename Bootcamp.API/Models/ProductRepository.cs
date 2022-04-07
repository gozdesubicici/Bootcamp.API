namespace Bootcamp.API.Models
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {
          new (){Id=1, Name="kalem 1", Price=100, Stock=200},
          new (){Id=2, Name="kalem 2", Price=100, Stock=200},
          new (){Id=3, Name="kalem 3", Price=100, Stock=200},
        };

        // Yukarıda private ile kapsülleme yaptık bunu dış dünyaya açmak için aşağıdaki metodu yazıyoruz.
        // public List<Product> GetAll()
        // {
        //    return _products;
        // }    ----> şeklinde yazıyorduk fakat tek satır kodumuz varsa lamda ile return yazmadan direkt yazabiliriz.

        public List<Product> GetAll() => _products;
        public Product GetById(int id) => _products.FirstOrDefault(x => x.Id == id);
        public void Save(Product newProduct) => _products.Add(newProduct);

        public void Update(Product updateProduct)
        {
            // Burdaki product'a atanan; productslara git bana datayı ver x'in idsi update edileceğe eşit olacak
            //var product = _products.FirstOrDefault(x => x.Id == updateProduct.Id);

            //product.Name = updateProduct.Name; 
            //product.Price = updateProduct.Price;    
            //product.Stock = updateProduct.Stock;

            // Bu products'ı değiştirdim ben bu products'ı aldıktan sonra tekrar güncellenmiş halini vermem lazım. İndeksini bulacağım.

            var productIndex = _products.FindIndex(x => x.Id == updateProduct.Id);

            _products[productIndex]= updateProduct ;


        }
        // Bana bitane int id gelecek ben bunu sileceğim.
        public void Delete(int id)
        {
            // Tabi silmeden önce silinecek datayı bulmalıyım.
            // Burada LinQ teknolojisinden faydalandık, LinQ bir sorgulama tekniğidir, farklı farklı veri kaynaklarına karşı sorgulama yapıyoruz.
            var product = _products.FirstOrDefault(x => x.Id == id);
            _products.Remove(product);
        }








    }
}
