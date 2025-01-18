using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Security.Claims;

namespace MyTracker.Middleware
{
    public class CustomAuthrizationAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Microsoft.Extensions.Primitives.StringValues tokens;
            context.HttpContext.Request.Headers.TryGetValue("Authorization", out tokens);
            var token = tokens.FirstOrDefault();

            if (!string.IsNullOrEmpty(token))
            {
                //var jwtService = (IJwtService)context.HttpContext.RequestServices.GetService(typeof(IJwtService));

                //if (jwtService.IsValidToken(token))
                //    return;
                //else
                //{
                //    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                //    context.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Invalid Token";
                //    context.Result = new JsonResult("Invalid Token")
                //    {
                //        Value = new { Status = "Unauthorized", Message = "Invalid Token" }
                //    };
                //}
            }
            else
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.ExpectationFailed;
                context.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Please Provide Token";
                context.Result = new JsonResult("Please Provide Token")
                {
                    Value = new { Status = "ExpectationFailed", Message = "Please Provide Token" }
                };
            }
        }
    }
}
