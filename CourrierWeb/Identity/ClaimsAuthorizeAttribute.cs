using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CourrierWeb.Identity
{
    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        public ClaimsAuthorizeAttribute()
        {

        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return base.AuthorizeCore(httpContext);
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                // auth failed or not yet logged in
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            var identity = (ClaimsIdentity)Thread.CurrentPrincipal.Identity;

            base.OnAuthorization(filterContext);
        }
    }
}