using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Bootcamp.API.Filters
{
    // Bu classın bir Filter olabilmesi için bir Interface implement edicem ya da bu Interfacei implement etmiş classtan miras alacağım.
    public class MyActionFilter : ActionFilterAttribute
    {

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            Debug.WriteLine("Action Method çağrılmadan önce");
            await next.Invoke();
            Debug.WriteLine("Action Method çağrıldıktan sonra");

        }

        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            Debug.WriteLine("Result çağrılmadan önce");
            await next.Invoke();
            Debug.WriteLine("Result çağrıldıktan sonra");
        }
    }
}
