using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository
{
    public class dob
    {
        public date date { get; set; }

        public string jsdate { get; set; }
        public string formatted { get; set; }

        public string epoc { get; set; }

    }

    public class date
    {
        public string year { get; set; }
        public string month { get; set; }
        public string day { get; set; }

    }

    public class time
    {
        public string hh { get; set; }
        public string min { get; set; }
        public string sec { get; set; }

    }

    public class RegistrationModel
    {
        public string profileCreateBy { get; set; }
        public object USER_ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string landline { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }
        public string maritalstatus { get; set; }
        public string gotra { get; set; }
        public dob dob { get; set; }
        public string birthplace { get; set; }
        public time time { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public string incomerange { get; set; }
        public string smokestatus { get; set; }
        public string dietstatus { get; set; }
        public string workstatus { get; set; }
        public string drinkstatus { get; set; }
        public string religion { get; set; }
        public string mothertounge { get; set; }
        public string rashi { get; set; }
        public string education { get; set; }
        public string profession { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string place { get; set; }
        public string zip { get; set; }
        public string about { get; set; }
        public string mySubCaste { get; set; }
        public string recaptcha { get; set; }

        public string email { get; set; }
        public string nativeplace { get; set; }
        public string mobile { get; set; }
        public string JsonRawData { get; set; }

        public int USER_PEROFILE_ID { get; set; }



        public string myFacebookId { get; set; }
        public string myTwitterId { get; set; }
        public string mylinkedinId { get; set; }

    }


    public class ProfileVisitor
    {

        public int profileId { get; set; }

        public string FULL_NAME { get; set; }

        public string EmailId { get; set; }
        public string VisitorEmailID { get; set; }
        public string VisitorID { get; set; }
        public string VisitorDate { get; set; }

        public string age { get; set; }

        public string maritialstatus { get; set; }

        public string gotra { get; set; }

        public string religion { get; set; }

        public string visitordate { get; set; }

        public string MY_OCCUPTION { get; set; }

        public string MY_SUB_CASTE { get; set; }

    }


    public class InterestShown
    {

        public string CommunicatorUserEmailId { get; set; }

        public string ResponderUserId { get; set; }

        public string ResponseStatus { get; set; }

        public string Message { get; set; }
        public string ContactEmailId { get; set; }

        public string ContactPhoneNumber { get; set; }

    }

    public class UserPics
    {
        public string emailId { get; set; }
        public string PicName { get; set; }
        public string PicFilePath { get; set; }
        public bool IsProfilePic { get; set; }
        public string CreatedBy { get; set; }
    }

    public class GetUserPics
    {
        public string id { get; set; }
        public string src { get; set; }
        public string text { get; set; }
        public string IsProfilePic { get; set; }

    }
    public class UpdateUserPics
    {

        public string PicId { get; set; }

    }

    public class GetRegistrationModel
    {
        public object USER_ID { get; set; }
        //  JsonProperty("JsonRawData")
        public string JsonRawData { get; set; }

        public int USER_PEROFILE_ID { get; set; }

    }


    public class GetShowInterestModel
    {
        public string message { get; set; }
        public string profileid { get; set; }
        public string name { get; set; }
        public string communicationDate { get; set; }
        public string E_MAIL { get; set; }
        public string status { get; set; }
    }


    public class GetForgetPassword
    {
        public string password { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }

    public class GetUserRequestsModel
    {
        public int TotalPendingResponseCount { get; set; }
        public int TotalRequestSendCount { get; set; }

        public int TotalRequestReceivedCount { get; set; }
        public int TotalRequestRejectCount { get; set; }

        public int TotalVisitorCount { get; set; }

    }

    public class GetMasterData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
    }


    public class GetUserMessages
    {
        public string message { get; set; }
        public string message_send_date { get; set; }
        public string message_sender { get; set; }

        public string E_MAIL { get; set; }

    }

    //public class GetMasterData
    //{
    //    public int id { get; set; }
    //    public int LOOKUP_ID { get; set; }
    //    public string name { get; set; }

    //}

    public class GetLoginInfo
    {
        public object Code { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }

    public class UserProfile
    {
        public object USER_ID { get; set; }
        public string USER_PEROFILE_ID { get; set; }
        public string PROFILE_CREATED_BY { get; set; }
        public string F_NAME { get; set; }
        public string L_NAME { get; set; }
        public string M_NAME { get; set; }
        public string FULL_NAME { get; set; }
        public string GENDER { get; set; }
        public string DOB { get; set; }
        public string birthplace { get; set; }
        public string TIME { get; set; }
        public string COUNTRY_ID { get; set; }
        public string CITY_ID { get; set; }
        public string ADDRESS { get; set; }
        public string E_MAIL { get; set; }
        public string CALCULATED_AGE { get; set; }
        public string workstatus { get; set; }
        public string MY_RELIGION { get; set; }
        public string MY_SUB_CASTE { get; set; }
        public string MY_RASHI { get; set; }
        public string MY_GOTHRA { get; set; }
        public string PHONE_NO1 { get; set; }
        public string PHONE_NO2 { get; set; }
        public string MOBILE_NO1 { get; set; }
        public string MARITIAL_STATUS { get; set; }
        public string MY_NATIVE_PLACE { get; set; }
        public string ABOUT_MY_PROFESSION { get; set; }
        public string MY_OCCUPTION { get; set; }
        public string MY_MIN_INCOME { get; set; }
        public string MY_MAX_INCOME { get; set; }
        public string MY_WORK_STATUS { get; set; }
        public string DIET_STATUS { get; set; }
        public string SMOKE_STATUS { get; set; }
        public string DRINK_STATUS { get; set; }
        public string BODY_TYPE { get; set; }
        public string HEIGHT { get; set; }
        public string WEIGHT { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_ON { get; set; }
        public string ABOUT_ME { get; set; }
        public string MY_MOTHER_TOUNG { get; set; }
        public string FACEBOOK_ID { get; set; }
        public string TWITTER_ID { get; set; }
        public string OTHERSOCIALNETWORKING_ID { get; set; }

        public string ABOUT_MY_EDUCATION { get; set; }
        public string COUNTRY { get; set; }
        public string CITY { get; set; }
        public string address { get; set; }

        public string lastLogin { get; set; }

    }
}