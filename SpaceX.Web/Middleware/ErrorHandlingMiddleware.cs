using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SpaceX.Web.Middleware
{
    /// <summary>
    /// The class handles the visualization of error messages in an user friendly way
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        #region Fields

        private readonly RequestDelegate next;

        #endregion

        #region Constructors

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        #endregion

        #region Methods

        public async Task Invoke(HttpContext httpContext)
        {
            await this.next(httpContext);

            httpContext.Response.Redirect("Home/Error");
        }

        #endregion
    }
}