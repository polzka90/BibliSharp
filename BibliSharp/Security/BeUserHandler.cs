using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace BibliSharp.Security
{
    public class BeUserRequirement : IAuthorizationRequirement
    {
        public BeUserRequirement(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; }
    }

    public class BeUserHandler : AuthorizationHandler<BeUserRequirement>
    {
        IHttpContextAccessor _httpContextAccessor = null;
        public BeUserHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BeUserRequirement requirement)
        {
            HttpContext httpContext = _httpContextAccessor.HttpContext; // Access context here

            string user = httpContext.Session.GetString("nomeUsuarioLogado");

            var redirectContext = context.Resource as AuthorizationFilterContext;

            if (!string.IsNullOrWhiteSpace(user) && user != requirement.UserName)
            {
                context.Succeed(requirement);
            }
            else
            {
                redirectContext.Result = new RedirectToActionResult("Login", "Home", null);
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
