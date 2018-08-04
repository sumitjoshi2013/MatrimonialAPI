using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using System.Web.Http.Cors;
using System.Configuration;
using Repository;
using DAL;

namespace WebApi.Jwt.Controllers
{
    // [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    [AllowAnonymous]
    public class TokenController : ApiController
    {
        public HttpResponseMessage Get(string username, string password)
        {
            if (CheckUser(username, password))
            {
                var token = JwtManager.GenerateToken(username);
                var response = Request.CreateResponse(HttpStatusCode.OK, token);
                return response;
            }
            else
            {
                var token = JwtManager.GenerateTokenFake(username);
                var response = Request.CreateResponse(HttpStatusCode.OK, token);
                return response;

            }
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }
        public bool CheckUser(string username, string password)
        {
            bool flag = true;
            GetLoginInfo getdata = getUserLoginInfoData(username, password);
            if(getdata.Code == null)
            {
                return flag = false;
            }
            return flag;
        }
        private GetLoginInfo getUserLoginInfoData(string username, string password)
        {
            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            var data = repository.GetUserLoginInfo(con, username, password);
            return data;
        }

        /*
     [HttpPost]
     public HttpResponseMessage Post(loginobject credentials)
     {

         if (CheckUser(credentials.email, credentials.password))
         {
             var token = JwtManager.GenerateToken(credentials.email);
             var response = Request.CreateResponse(HttpStatusCode.OK, token);
             return response;
         }

         throw new HttpResponseException(HttpStatusCode.Accepted);
     }
     */
    }
}