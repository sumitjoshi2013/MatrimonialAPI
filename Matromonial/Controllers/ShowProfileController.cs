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
    public class ShowProfileController : ApiController
    {
        // GET: api/ShowProfile
        [HttpGet, ActionName("ShowProfile")]
        public IEnumerable<GetShowInterestModel> Get(string userid)
        {
            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetInterestShownProfiles(con, userid);
        }
        [HttpGet, ActionName("ShowUserProfileByUniqueId")]
        public UserProfile GetShowUserProfileByUniqueId(string userid)
        {
            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetShowUserProfileByUniqueId(con, userid);
        }
        

        // GET: api/ShowProfile/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ShowProfile
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ShowProfile/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ShowProfile/5
        public void Delete(int id)
        {
        }
    }
}
