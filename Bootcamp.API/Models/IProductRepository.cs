namespace Bootcamp.API.Models
{
    public interface IProductRepository
    {
        public List<Product> GetAll();
        public Product GetById(int id);
        public void Save(Product newProduct);

        public void Update(Product updateProduct);

        public void Delete(int id);
    }
}
