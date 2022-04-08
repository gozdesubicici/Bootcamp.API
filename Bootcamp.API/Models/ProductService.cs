using Bootcamp.API.Controllers;
using Bootcamp.API.DTOs;
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

        public ResponseDto<ProductDto> GetById(int id)
        {
            var hasProduct = _repository.GetById(id);

            if (hasProduct == null)
            {
                return ResponseDto<ProductDto>.Fail($"Id({id})'ye sahip ürün bulunamammıştır.", 404);
            }
            else
                return ResponseDto<ProductDto>.Success(new ProductDto(hasProduct), 200);
        }
        public IActionResult Save(Product newProduct)
        {
            _repository.Save(newProduct);
            return new CreatedAtActionResult(nameof(ProductsController.GetProducts), "Products", new { id = newProduct.Id }, newProduct);
        }

        public ResponseDto<NoContent> Update(Product updateProduct)
        {

            var hasProduct = _repository.GetById(updateProduct.Id);

            if (hasProduct == null) return ResponseDto<NoContent>.Fail($"Id({updateProduct.Id})'ye sahip ürün bulunamammıştır.", 404);

            _repository.Update(updateProduct);
            return ResponseDto<NoContent>.Success(204);


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
