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
    public class VisitorDetailsController : ApiController
    {
        // GET: api/VisitorDetails
        public IEnumerable<ProfileVisitor> Get(string userid)
        {
            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetProfileVisitor(con, userid);
        }

      
        // POST: api/VisitorDetails
        public string Post(ProfileVisitor value)
        {
            var data = value;
            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.InsertProfileVisitor(con, data);
        }

       
    }
}
