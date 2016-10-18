﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yelo.Api.Filters;
using Yelo.BusinessServices.Interfaces;

namespace Yelo.Api.Controllers
{
   [APIAuthenticationFilter]  
    public class AuthenticateController: ApiController {

       #region Private variable.  
  
        private readonly ITokenServices _tokenServices;  
 
        #endregion  
 
        #region Public Constructor  
  
        /// <summary>  
        /// Public constructor to initialize product service instance  
        /// </summary>  
        public AuthenticateController(ITokenServices tokenServices) {  
            _tokenServices = tokenServices;  
        }  
 
        #endregion  
  
        /// <summary>  
        /// Authenticates user and returns token with expiry.  
        /// </summary>  
        /// <returns></returns>  
        //[HttpPost("login")]
        //[HttpPost("authenticate")]
        //[HttpPost("get/token")]  
        public HttpResponseMessage Authenticate() {  
            if (System.Threading.Thread.CurrentPrincipal != null && System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated) {  
                var basicAuthenticationIdentity = System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;  
                if (basicAuthenticationIdentity != null) {  
                    var userId = basicAuthenticationIdentity.UserId;  
                    return GetAuthToken(userId);  
                }  
            }  
            return null;  
        }  
  
        /// <summary>  
        /// Returns auth token for the validated user.  
        /// </summary>  
        /// <param name="userId"></param>  
        /// <returns></returns>  
        private HttpResponseMessage GetAuthToken(int userId) {  
            var token = _tokenServices.GenerateToken(userId);  
            var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");  
            response.Headers.Add("Token", token.AuthToken);  
            // response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);  
            response.Headers.Add("TokenExpiry", "20");  
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");  
            return response;  
        }  
    }  
}
