using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Bootcamp.API.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {

        public override Task OnExceptionAsync(ExceptionContext context)
        {
            context.ExceptionHandled = true; // Bu hatayı kendim ele alacağım demek.

            Debug.WriteLine("Exception Filter çalıştı");
             

            return base.OnExceptionAsync(context);
        }
    }
}
