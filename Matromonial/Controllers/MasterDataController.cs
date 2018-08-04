
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
    public class MasterDataController : ApiController
    { 
        // GET: api/MasterData 

        [HttpGet, ActionName("BasicProfileDetails")]
        public RegistrationModel GetBasicProfileDetails(string userid)
        {

            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetBasicProfileDetails(con, "GetBasicProfileDetails", userid);
        }

        [HttpGet, ActionName("AcceptMaster")]
        public IEnumerable<GetMasterData> GetAcceptMaster()
        {

            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetMasterData(con,  "GetAcceptMaster");
        }
        [HttpGet, ActionName("CasteMaster")]
        public IEnumerable<GetMasterData> GetCasteMaster()
        {

            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetMasterData(con,  "GetCasteMaster");
        }
        [HttpGet, ActionName("DrinkMaster")]
        public IEnumerable<GetMasterData> GetDrinkMaster()
        {

            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetMasterData(con,  "GetDrinkMaster");
        }
        [HttpGet, ActionName("GenderMaster")]
        public IEnumerable<GetMasterData> GetGenderMaster()
        {

            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetMasterData(con,  "GetGenderMaster");
        }
        [HttpGet, ActionName("JobMaster")]
        public IEnumerable<GetMasterData> GetJobMaster()
        {

            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetMasterData(con,  "GetJobMaster");
        }
        [HttpGet, ActionName("LanguageMaster")]
        public IEnumerable<GetMasterData> GetLanguageMaster()
        {

            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetMasterData(con,  "GetLanguageMaster");
        }

        [HttpGet, ActionName("MaritialStatusMaster")]
        public IEnumerable<GetMasterData> GetMaritialStatusMaster()
        {

            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetMasterData(con,  "GetMaritialStatusMaster");
        }
        [HttpGet, ActionName("ProfileCreatedByMaster")]
        public IEnumerable<GetMasterData> GetProfileCreatedByMaster()
        {

            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetMasterData(con,  "GetProfileCreatedByMaster");
        }
        [HttpGet, ActionName("RashiMaster")]
        public IEnumerable<GetMasterData> GetRashiMaster()
        {

            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetMasterData(con,  "GetRashiMaster");
        }

        [HttpGet, ActionName("ReligionMaster")]
        public IEnumerable<GetMasterData> GetReligionMaster()
        {

            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetMasterData(con,  "GetReligionMaster");
        }
        [HttpGet, ActionName("SalaryMaster")]
        public IEnumerable<GetMasterData> GetSalaryMaster()
        {

            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetMasterData(con,  "GetSalaryMaster");
        }
        [HttpGet, ActionName("SmokingMaster")]
        public IEnumerable<GetMasterData> GetSmokingMaster()
        {

            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetMasterData(con,  "GetSmokingMaster");
        }

        [HttpGet, ActionName("CityMaster")]
        public IEnumerable<GetMasterData> GetCityMaster()
        {

            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetMasterData(con,  "GetStateMaster");
        }
        [HttpGet, ActionName("VegMaster")]
        public IEnumerable<GetMasterData> GetVegMaster()
        {

            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetMasterData(con,  "GetVegMaster");
        }

        [HttpGet, ActionName("MotherToungeMaster")]
        public IEnumerable<GetMasterData> GetMotherToungeMaster()
        {

            string con = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            CRUD repository = new CRUD();
            return repository.GetMasterData(con,  "GetMotherToungeMaster");
        }
    

    }
}
