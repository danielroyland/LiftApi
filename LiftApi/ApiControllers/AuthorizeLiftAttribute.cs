using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace LiftApi.ApiControllers
{
    public class AuthorizeLiftAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (Authorize(actionContext))
            {
                return;
            }
            HandleUnauthorizedRequest(actionContext);
        }
        protected override void HandleUnauthorizedRequest(HttpActionContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }

        private static bool Authorize(HttpActionContext actionContext)
        {
            try
            {
                var headers = actionContext.Request.Headers;
                var tokenRequest = headers.GetValues("Token").First();

                const string apiToken = "benkOgBiceps";
                
                return tokenRequest == apiToken;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}