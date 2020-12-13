using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SpaceX.Web.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await this.next(httpContext);

            httpContext.Response.Redirect("Home/Error");
        }
    }
}
