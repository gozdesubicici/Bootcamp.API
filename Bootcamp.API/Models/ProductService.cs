using Bootcamp.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.API.Models
{
    public class ProductService
    {
        // readonly değişmesin diye
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public IActionResult GetAll() => new OkObjectResult(_repository.GetAll());
        public IActionResult GetById(int id)
        {
            var hasProduct = _repository.GetById(id);

            if (hasProduct == null) return new NotFoundResult();
            else return new OkObjectResult(hasProduct);
        }
        public IActionResult Save(Product newProduct)
        {
            _repository.Save(newProduct);
            return new CreatedAtActionResult(nameof(ProductsController.GetProducts), "Products", new { id = newProduct.Id }, newProduct);
        }

        public IActionResult Update(Product updateProduct)
        {

            var hasProduct = _repository.GetById(updateProduct.Id);

            if (hasProduct == null) return new NotFoundResult();

            _repository.Update(updateProduct);
            return new NoContentResult();


        }
        
        public IActionResult Delete(int id)
        {
            var hasProduct = _repository.GetById(id);

            if (hasProduct == null) return new NotFoundResult();

            _repository.Delete(id);

            return new NoContentResult();

        }
    }
}
