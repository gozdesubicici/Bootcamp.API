namespace Bootcamp.API.Middlewares
{
    public class IPAddressControlMiddleware
    {
        private readonly RequestDelegate requestDelegate;
        private readonly IConfiguration _configuration;
        public IPAddressControlMiddleware(RequestDelegate requestDelegate, IConfiguration configuration)
        {
            this.requestDelegate = requestDelegate;
            _configuration = configuration;
        }


        public async Task InvokeAsync(HttpContext context)
        {


            var reqIpAddress = context.Connection.RemoteIpAddress;

            //  var ipAddress = IPAddress.Parse("::1");


            if (IPAddress.Parse(_configuration["WhiteIPAddress"]).Equals(reqIpAddress))
            {
                await requestDelegate.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await context.Response.WriteAsync("Forbidden");

            }


            // IPV4   IPV6
            // Localhost: 127.0.0.1
            // Localhost : ::1
        }
    }
