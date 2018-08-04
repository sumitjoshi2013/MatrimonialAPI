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
    public class ShowInterestController : ApiController
    {
        // GET: api/ShowInterest
        public IEnumerable<GetShowInterestModel> Get(string userid)
        {
            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetInterestShownProfiles(con, userid);
        }

        // POST: api/ShowInterest
        public string Post(InterestShown value)
        {
            var data = value;
            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.InsertUserInterestShown(con, data);
        }
       
    }
}
