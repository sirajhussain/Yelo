using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using Yelo.BusinessServices.Interfaces;

namespace Yelo.Api.Filters
{
    /// <summary>  
    /// Custom Authentication Filter Extending basic Authentication  
    /// </summary>  
    public class APIAuthenticationFilter : GenericAuthenticationFilter
    {
        /// <summary>  
        /// Default Authentication Constructor  
        /// </summary>  
        public APIAuthenticationFilter() {}  
  
        /// <summary>  
        /// AuthenticationFilter constructor with isActive parameter  
        /// </summary>  
        /// <param name="isActive"></param>  
        public APIAuthenticationFilter(bool isActive): base(isActive) {}  
  
        /// <summary>  
        /// Protected overriden method for authorizing user  
        /// </summary>  
        /// <param name="username"></param>  
        /// <param name="word"></param>  
        /// <param name="actionContext"></param>  
        /// <returns></returns>  
        protected override bool OnAuthorizeUser(string username, string phoneNumber, HttpActionContext actionContext) {  
            var provider = actionContext.ControllerContext.Configuration.DependencyResolver.GetService(typeof(IUserServices)) as IUserServices;  
            if (provider != null) {
                var userId = provider.Authenticate(username, phoneNumber);  
                if (userId > 0) {  
                    var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;  
                    if (basicAuthenticationIdentity != null) basicAuthenticationIdentity.UserId = userId;  
                    return true;  
                }  
            }  
            return false;  
        }  
    }  
}