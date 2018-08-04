using DAL;
using Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class UserRequestsController : ApiController
    {
        // GET: api/UserRequests
        public GetUserRequestsModel GetUserRequestsCounts(string userid)
        {

            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetUserRequestsCounts(con, userid);
        }
        // GET: api/UserRequests/5
      
    }
}
