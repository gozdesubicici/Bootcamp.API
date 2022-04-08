using Bootcamp.API.DTOs;
using Bootcamp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bootcamp.API.Filters
{
    public class NotFoundProductFilter : ActionFilterAttribute
    {
        private readonly IProductRepository _productRepository;

        public NotFoundProductFilter(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = (int)context.HttpContext.Request.RouteValues["id"];

            var hasProduct = _productRepository.GetById(id);

            if (hasProduct != null)
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(ResponseDto<NoContent>.Fail($"Id({id})'ye sahip ürün bulunamammıştır.",404));
        }
    }
}
