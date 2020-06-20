using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using ServerApp.Data;
using System;

namespace ServerApp.Helpers
{
    public class LastActiveActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, 
        ActionExecutionDelegate next)
        {
           var resultContext = await next();

            var id = int.Parse(resultContext.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value);

            var repository = (ISocialRepository)resultContext.HttpContext
                        .RequestServices.GetService(typeof(ISocialRepository));

            var user = await repository.GetUser(id);
            user.LastActive = DateTime.Now;
            await repository.SaveChanges();
        }
    }
}