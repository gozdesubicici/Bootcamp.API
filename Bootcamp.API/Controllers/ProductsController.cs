using Bootcamp.API.Filters;
using Bootcamp.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Http Metot Types, URL, Route, QueryString
        //[HttpGet]
        ////localhost:5500/api/products
        //public IActionResult GetProducts()
        //{ 
        //    return Ok("Merhaba Dünya[GET]");
        //}

        ////api/products
        //[HttpGet("{id}")]
        ////localhost:5500/api/products
        //public IActionResult GetProducts(int id)
        //{
        //    //Route değer okumak istiyorsak {placeholder}
        //    //QueryString'de değer okumak istiyosan 
        //    return Ok("Merhaba Dünya[GET]");
        //}



        //[HttpPost]
        //public IActionResult SaveProducts()
        //{
        //    return Ok("Merhaba Dünya[POST]");
        //}

        //bodyden almak için
        //[FromBody] sıkıştığımız zaman kullacağız. Örneğin tc gibi bir bilgiyi QueryString ile ya da route'a yazmak yerine bodyden almak için kullanabiliriz.
        //[FromBody] Action metotun parametlerinden yalnızca biri için kullanabilirsin. 
        //[HttpPost]
        //public IActionResult SaveProducts([FromBody] string tcNo)
        //{
        //    return Ok("Merhaba Dünya[POST]");
        //}

        //[HttpGet("{id}/{name}/{price}/{stock}")]
        //public IActionResult SaveProducts([FromRoute] Product product)
        //{
        //    return Ok("Merhaba Dünya[POST]");
        //}



        //[HttpPut]
        //public IActionResult UpdateProducts()
        //{
        //    return Ok("Merhaba Dünya[PUT]");
        //}

        //[HttpDelete]
        //public IActionResult DeleteProducts()
        //{
        //    return Ok("Merhaba Dünya[Delete]");
        //}
        #endregion

        #region ProductsController Codes

        private readonly ProductService _productService;
        public ProductsController(ProductService productService) // Constructor Injection 
        {
            _productService = productService;
        }

        [HttpGet("/api/[controller]/[action]/{id:int}")] // başına / koyunca default route eklenmiyor
        public IActionResult AnyProduct(int id)
        {
            return Ok();
        }


        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productService.GetAll());
        }


        [MyActionFilter]
        [HttpGet("{id}")]
        public IActionResult GetProducts(int id)
        {
            var result= _productService.GetById(id);

            return new ObjectResult(result) { StatusCode = result.StatusCode };
        }

        [HttpPost]
        public IActionResult SaveProducts(Product newProduct)
        {
            return _productService.Save(newProduct);

            // 1.Yol
            //return CreatedAtAction(nameof(GetProducts), new {id = newProduct.Id }, newProduct);

            // 2.Yol
            //return Created($"api/products/{newProduct.Id}", newProduct);
        }

        [HttpPut]
        public IActionResult UpdateProducts(Product updateProduct)
        {
            var result = _productService.Update(updateProduct);

            return new ObjectResult(result) { StatusCode = result.StatusCode };
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProducts(int id)
        {
            return _productService.Delete(id);
        }

        #endregion
    }
}
