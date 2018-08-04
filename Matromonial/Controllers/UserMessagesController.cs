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
    public class UserMessagesController : ApiController
    {
        // GET: api/UserMessages
        [HttpGet, ActionName("ShowInterest")]
        public IEnumerable<GetShowInterestModel> GetShowInterest(string ResponderEmailId)
        {
            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetInterestShownProfiles(con, ResponderEmailId);
        }

        [HttpGet, ActionName("UserLogMessages")]
        public IEnumerable<GetUserMessages> GetUserLogMessages(string ResponderEmailId)
        {
            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetUserMessages(con, ResponderEmailId);
        }

        [HttpGet, ActionName("UserLogReqSendMessages")]
        public IEnumerable<GetUserMessages> GetUserLogReqSendMessages(string ResponderEmailId)
        {
            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetUserLogReqSendMessages(con, ResponderEmailId);
        }

        [HttpGet, ActionName("UserLogReqReceivedMessages")]
        public IEnumerable<GetUserMessages> GetUserLogReqReceivedMessages(string ResponderEmailId)
        {
            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetUserLogReqReceivedMessages(con, ResponderEmailId);
        }
        // GET: api/UserMessages/5

        //

        [HttpGet, ActionName("UserLogReqRejectedMessages")]
        public IEnumerable<GetUserMessages> GetUserLogReqRejectedMessages(string ResponderEmailId)
        {
            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetUserLogReqRejectedMessages(con, ResponderEmailId);
        }

        //
        [HttpGet, ActionName("UserLogReqPendingMessages")]
        public IEnumerable<GetUserMessages> GetUserLogReqPendingMessages(string ResponderEmailId)
        {
            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetUserLogReqPendingMessages(con, ResponderEmailId);
        }

        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserMessages
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserMessages/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserMessages/5
        public void Delete(int id)
        {
        }
    }
}
