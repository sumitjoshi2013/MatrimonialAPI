using Dal;
using Dapper;
using Helper;
using Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DAL
{
    public class CRUD
    {

        public string InsertUserProfile(string conn, RegistrationModel registrationModel)
        {
            string msg = string.Empty;
            SqlHelper sqlHelper = new SqlHelper(conn);

            var para = new DynamicParameters();
            var outPut = new DynamicParameters();

            try
            {
                string dt = registrationModel.dob.formatted;

                para.Add("@PROFILE_CREATED_BY", registrationModel.profileCreateBy);
                para.Add("@F_NAME", registrationModel.firstName);
                para.Add("@L_NAME", registrationModel.lastName);
                para.Add("@COUNTRY_ID", registrationModel.country);
                para.Add("@CITY_ID", registrationModel.city);
                para.Add("@ADDRESS", registrationModel.address);
                para.Add("@E_MAIL", registrationModel.email);
                para.Add("@PASSWORD", registrationModel.password);
                para.Add("@DOB", dt);// registrationModel.dob.date );
                para.Add("@TIME", registrationModel.time.hh + ":" + registrationModel.time.min + ":" + registrationModel.time.sec);
                para.Add("@Placeofbirth", registrationModel.birthplace);
                para.Add("@MY_RELIGION", registrationModel.religion);
                para.Add("@MY_MOTHER_TOUNG", registrationModel.mothertounge);
                para.Add("@MY_SUB_CASTE", registrationModel.mySubCaste);
                para.Add("@MY_RASHI", registrationModel.rashi);
                para.Add("@MY_GOTHRA", registrationModel.gotra);
                para.Add("@MY_NATIVE_PLACE", registrationModel.nativeplace);
                para.Add("@PHONE_NO1", registrationModel.landline);
                para.Add("@PHONE_NO2", registrationModel.landline);
                para.Add("@MOBILE_NO1", registrationModel.mobile);
                para.Add("@MARITIAL_STATUS", registrationModel.maritalstatus);
                para.Add("@ABOUT_ME", registrationModel.about);
                para.Add("@ABOUT_MY_EDUCATION", registrationModel.education);
                para.Add("@ABOUT_MY_PROFESSION", registrationModel.profession);
                para.Add("@MY_HIGHEST_DEGREE", registrationModel.education);
                para.Add("@MY_MIN_INCOME", registrationModel.incomerange);
                para.Add("@MY_MAX_INCOME", registrationModel.incomerange);
                para.Add("@MY_WORK_STATUS", registrationModel.workstatus);
                para.Add("@DIET_STATUS", registrationModel.dietstatus);
                para.Add("@SMOKE_STATUS", registrationModel.smokestatus);
                para.Add("@DRINK_STATUS", registrationModel.drinkstatus);
                para.Add("@HEIGHT", registrationModel.height);
                para.Add("@WEIGHT", registrationModel.weight);
                para.Add("@UPDATE_PROFILE_ID", "");
                para.Add("@CREATED_BY", "");
                para.Add("@MODIFIED_BY", "");
                para.Add("@STATUS", 1);
                para.Add("@GENDER", registrationModel.gender);

                para.Add("@FACEBOOK_ID", registrationModel.myFacebookId);
                para.Add("@TWITTER_ID", registrationModel.myTwitterId);
                para.Add("@LINKEDIN_ID", registrationModel.mylinkedinId);



                var json = new JavaScriptSerializer().Serialize(registrationModel);
                para.Add("@JSONObject", "");
            }
            catch (Exception exp)
            {
                msg = "Error :" + exp.Message;
            }
            try
            {
                sqlHelper.ExecuteSp("InsertProfile", para, null, true, null);
                msg = "Successfully Inserted Data.";
            }
            catch (Exception exp)
            {
                msg = "Error :" + exp.Message;
            }
            //int valueout = para.Get<int>("@outresult");
            return msg;
        }

        public string InsertUserProfileBasic(string conn, RegistrationModel registrationModel)
        {
            string msg = string.Empty;
            SqlHelper sqlHelper = new SqlHelper(conn);

            var para = new DynamicParameters();
            var outPut = new DynamicParameters();

            try
            {
                //string dt = registrationModel.dob.formatted;
                para.Add("@F_NAME", registrationModel.firstName);
                para.Add("@L_NAME", registrationModel.lastName);
                para.Add("@E_MAIL", registrationModel.email);
                para.Add("@PASSWORD", registrationModel.password);
                para.Add("@MOBILE_NO1", registrationModel.mobile);
                para.Add("@PHONE_NO1", registrationModel.landline);
                para.Add("@GENDER", registrationModel.gender);
                para.Add("@PROFILE_CREATED_BY", registrationModel.profileCreateBy);
                para.Add("@CREATED_BY", "");
                para.Add("@MODIFIED_BY", "");
                para.Add("@ACTIVE", 0);

                var json = new JavaScriptSerializer().Serialize(registrationModel);
                //para.Add("@JSONObject", "");
            }
            catch (Exception exp)
            {
                msg = "Error :" + exp.Message;
            }
            try
            {
                sqlHelper.ExecuteSp("InsertProfileRegistrationBasic", para, null, true, null);
                msg = "Successfully Inserted Data.";
            }
            catch (Exception exp)
            {
                msg = "Error :" + exp.Message;
            }
            //int valueout = para.Get<int>("@outresult");
            return msg;
        }

        //
        public List<GetUserPics> GetUserPics(string conn, string emailid)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string readSp = "GetUserPics";
                var para = new DynamicParameters();
                para.Add("@emailid", emailid);
                var data = db.Query<GetUserPics>(readSp, para, commandType: CommandType.StoredProcedure).ToList();
                return data;
            }
        }

        public List<UserProfile> GetProfiles(string conn, string emailid)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string readSp = "GetProfiles";
                var para = new DynamicParameters();
                para.Add("@emailid", emailid);
                var data = db.Query<UserProfile>(readSp, para, commandType: CommandType.StoredProcedure).ToList();
                return data;
            }
        }
        public string GetForgetUserIdToEmail(string conn, string emailid)
        {
            Utility utility = new Utility();
            using (IDbConnection db = new SqlConnection(conn))
            {
                string readSp = "GetForgetPassword";
                var para = new DynamicParameters();
                para.Add("@Useremailid", emailid);
                var data = db.Query<GetForgetPassword>(readSp, para, commandType: CommandType.StoredProcedure).SingleOrDefault();

                if (data == null)
                {
                    return "Please provide a valid Email ID or contact the Administrator.";
                }
                bool returnFlag = utility.MailSend(data.email, "", "");
                if (returnFlag == true)
                    return "Successfully Send the Mail";
                else
                    return "Error.";

            }
        }

        public List<GetShowInterestModel> GetInterestShownProfiles(string conn, string emailId)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string readSp = "GetInterestedProfilesByEmailId";
                var para = new DynamicParameters();
                para.Add("@E_MAIL", emailId);
                var data = db.Query<GetShowInterestModel>(readSp, para, commandType: CommandType.StoredProcedure).ToList();
                return data;
            }
        }
        public List<GetShowInterestModel> GetCountOfPendingResponseByEmailId(string conn, string emailId)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string readSp = "GetCountOfPendingResponseByEmailId";
                var para = new DynamicParameters();
                para.Add("@E_MAIL", emailId);
                var data = db.Query<GetShowInterestModel>(readSp, para, commandType: CommandType.StoredProcedure).ToList();
                return data;
            }
        }


        public GetUserRequestsModel GetUserRequestsCounts(string conn, string emailId)
        {
            GetUserRequestsModel getUserRequestsModel = new GetUserRequestsModel();
            using (IDbConnection db = new SqlConnection(conn))
            {
                string readSp = "GetUserRequestsCounts";
                var para = new DynamicParameters();
                para.Add("@E_MAIL", emailId);
                using (var multi = db.QueryMultiple(readSp, para, commandType: CommandType.StoredProcedure))
                {
                    getUserRequestsModel.TotalRequestSendCount = multi.Read<int>().Single();
                    getUserRequestsModel.TotalPendingResponseCount = multi.Read<int>().Single();
                    getUserRequestsModel.TotalRequestReceivedCount = multi.Read<int>().Single();
                    getUserRequestsModel.TotalRequestRejectCount = multi.Read<int>().Single();
                    getUserRequestsModel.TotalVisitorCount = multi.Read<int>().Single();
                }

                // var data = db.Query<GetUserRequestsModel>(readSp, para, commandType: CommandType.StoredProcedure).ToList();
                return getUserRequestsModel;
            }
        }

        public RegistrationModel GetBasicProfileDetails(string conn, string readSp, string userid)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                var para = new DynamicParameters();
                para.Add("@emailId", userid);
                var data = db.Query<RegistrationModel>(readSp, para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                return data;
            }
        }
        public List<GetMasterData> GetMasterData(string conn, string readSp)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                var data = db.Query<GetMasterData>(readSp, commandType: CommandType.StoredProcedure).ToList();
                return data;
            }
        }

        public List<UserProfile> GetShowUserProfiles(string conn, string userid)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string readSp = "GetProfileDetails";
                var para = new DynamicParameters();
                para.Add("@USER_ID", userid);
                var data = db.Query<UserProfile>(readSp, para, commandType: CommandType.StoredProcedure).ToList();
                return data;
            }
        }


        public UserProfile GetShowUserProfileByUniqueId(string conn, string userid)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string readSp = "GetProfileDetailByUniqueId";
                var para = new DynamicParameters();
                para.Add("@User_Id", userid);
                var data = db.Query<UserProfile>(readSp, para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                return data;
            }
        }

        public List<GetUserMessages> ShowInterest(string conn, string ResponderEmailId)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string readSp = "GetShowInterest";
                var para = new DynamicParameters();
                para.Add("@ResponderEmailId", ResponderEmailId);
                var data = db.Query<GetUserMessages>(readSp, para, commandType: CommandType.StoredProcedure).ToList();
                return data;
            }
        }


        public List<GetUserMessages> GetUserMessages(string conn, string ResponderEmailId)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string readSp = "GetUserMessage";
                var para = new DynamicParameters();
                para.Add("@ResponderEmailId", ResponderEmailId);
                var data = db.Query<GetUserMessages>(readSp, para, commandType: CommandType.StoredProcedure).ToList();
                return data;
            }
        }

        public List<GetUserMessages> GetUserLogReqSendMessages(string conn, string ResponderEmailId)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string readSp = "GetUserLogReqSendMessages";
                var para = new DynamicParameters();
                para.Add("@ResponderEmailId", ResponderEmailId);
                var data = db.Query<GetUserMessages>(readSp, para, commandType: CommandType.StoredProcedure).ToList();
                return data;
            }
        }


        public List<GetUserMessages> GetUserLogReqReceivedMessages(string conn, string ResponderEmailId)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string readSp = "GetUserLogReqReceivedMessages";
                var para = new DynamicParameters();
                para.Add("@ResponderEmailId", ResponderEmailId);
                var data = db.Query<GetUserMessages>(readSp, para, commandType: CommandType.StoredProcedure).ToList();
                return data;
            }
        }

        public List<GetUserMessages> GetUserLogReqRejectedMessages(string conn, string ResponderEmailId)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string readSp = "GetUserLogReqRejectedMessages";
                var para = new DynamicParameters();
                para.Add("@ResponderEmailId", ResponderEmailId);
                var data = db.Query<GetUserMessages>(readSp, para, commandType: CommandType.StoredProcedure).ToList();
                return data;
            }
        }
        //
        public List<GetUserMessages> GetUserLogReqPendingMessages(string conn, string ResponderEmailId)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string readSp = "GetUserLogReqPendingMessages";
                var para = new DynamicParameters();
                para.Add("@E_MAIL", ResponderEmailId);
                var data = db.Query<GetUserMessages>(readSp, para, commandType: CommandType.StoredProcedure).ToList();
                return data;
            }
        }
        public List<GetMasterData> GetMasterData(string conn)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string readSp = "GetMasterData";
                var data = db.Query<GetMasterData>(readSp, commandType: CommandType.StoredProcedure).ToList();
                return data;
            }
        }

        public GetRegistrationModel GetProfileById(string conn, string Id)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string readSp = "GetProfileById";
                var para = new DynamicParameters();
                para.Add("@USER_PEROFILE_ID", Id);
                var data = db.Query<GetRegistrationModel>(readSp, para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                return data;
            }
        }

        public GetLoginInfo GetUserLoginInfo(string conn, string uid, string pwd)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string readSp = "GetLogin";
                var para = new DynamicParameters();
                para.Add("@UK_useremailid", uid);
                para.Add("@UK_PASSWORD", pwd);
                var data = db.Query<GetLoginInfo>(readSp, para, commandType: CommandType.StoredProcedure).SingleOrDefault();
                return data;
            }
        }

        public List<ProfileVisitor> GetProfileVisitor(string conn, string userId)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string readSp = "GetVisitorDetails";
                var para = new DynamicParameters();
                para.Add("@UserEmailId", userId);
                var data = db.Query<ProfileVisitor>(readSp, para, commandType: CommandType.StoredProcedure).ToList();
                return data;
            }
        }

        public string InsertProfileVisitor(string conn, ProfileVisitor profileVisitor)
        {
            string msg = string.Empty;
            SqlHelper sqlHelper = new SqlHelper(conn);

            var para = new DynamicParameters();
            var outPut = new DynamicParameters();

            try
            {
                para.Add("@UserEmailId", profileVisitor.EmailId);
                para.Add("@VisitorEmailID", profileVisitor.VisitorEmailID);
            }
            catch (Exception exp)
            {
                msg = "Error :" + exp.Message;
            }
            try
            {
                sqlHelper.ExecuteSp("InsertVisitorDetails", para, null, true, null);
                msg = "Successfully Inserted Data.";
            }
            catch (Exception exp)
            {
                msg = "Error :" + exp.Message;
            }
            //int valueout = para.Get<int>("@outresult");
            return msg;
        }


        public string UpdateProfilePic(string conn, UpdateUserPics userPics)
        {
            string msg = string.Empty;
            SqlHelper sqlHelper = new SqlHelper(conn);
            var para = new DynamicParameters();
            var outPut = new DynamicParameters();
            try
            {
                para.Add("@PicID", userPics.PicId);
            }
            catch (Exception exp)
            {
                msg = "Error :" + exp.Message;
            }
            try
            {
                var result = sqlHelper.ExecuteSpReturnMessage("UpdateUserProfilePic", para, null, true, null);
                msg = "Successfully Update Profile Pic.";
            }
            catch (Exception exp)
            {
                msg = "Error :" + exp.Message;
            }
            //int valueout = para.Get<int>("@outresult");
            return msg;
        }

        public string DeletePic(string conn, UpdateUserPics userPics)
        {
            string msg = string.Empty;
            SqlHelper sqlHelper = new SqlHelper(conn);
            var para = new DynamicParameters();
            var outPut = new DynamicParameters();
            try
            {
                para.Add("@PicID", userPics.PicId);
            }
            catch (Exception exp)
            {
                msg = "Error :" + exp.Message;
            }
            try
            {
                var result = sqlHelper.ExecuteSpReturnMessage("DeleteUserPic", para, null, true, null);
                msg = "Successfully Update Profile Pic.";
            }
            catch (Exception exp)
            {
                msg = "Error :" + exp.Message;
            }
            //int valueout = para.Get<int>("@outresult");
            return msg;
        }

        public string InsertUserProfilePics(string conn, UserPics userPics)
        {

            string msg = string.Empty;
            SqlHelper sqlHelper = new SqlHelper(conn);
            var para = new DynamicParameters();
            var outPut = new DynamicParameters();
            try
            {
                para.Add("@UserEmail_ID", userPics.emailId);
                para.Add("@PicName", userPics.PicName);
                para.Add("@PicFilePath", userPics.PicFilePath);
                if (userPics.IsProfilePic)
                    para.Add("@IsProfilePic", 1);
                else
                    para.Add("@IsProfilePic", 0);
                para.Add("@CREATED_BY", userPics.emailId);

            }
            catch (Exception exp)
            {
                msg = "Error :" + exp.Message;
            }
            try
            {
                var getUserPics = GetUserPics(conn, userPics.emailId);

                if (getUserPics.Count() >= 5) // maximum 5 pics can be uploaded
                {
                    msg = "You cannot insert more then 5 pics.";
                    return msg;
                }

                else
                {   //lamda to check the profile pic
                    var userpics = getUserPics.Where(c => c.IsProfilePic.ToUpper() == "TRUE".ToUpper()).ToList();
                    if (userpics.Count() >= 1)
                    {
                        msg = "You have already set the Profile Pic. Please uncheck the the profile pic status.";
                        return msg;
                    }
                    else
                    {
                        var result = sqlHelper.ExecuteSpReturnMessage("InsertUserPics", para, null, true, null);
                        msg = "Successfully Inserted Pics.";
                    }

                }
            }
            catch (Exception exp)
            {
                msg = "Error :" + exp.Message;
            }
            //int valueout = para.Get<int>("@outresult");
            return msg;
        }

        public string InsertUserInterestShown(string conn, InterestShown interestShown)
        {
            string msg = string.Empty;
            SqlHelper sqlHelper = new SqlHelper(conn);
            var para = new DynamicParameters();
            var outPut = new DynamicParameters();
            try
            {
                para.Add("@CommunicatorUserEmailId", interestShown.CommunicatorUserEmailId);
                para.Add("@ResponderUserId", interestShown.ResponderUserId);
                para.Add("@ResponseStatus", interestShown.ResponseStatus);
                para.Add("@Message", interestShown.Message);
                para.Add("@ContactPhoneNumber", interestShown.ContactPhoneNumber);
                para.Add("@ContactEmailId", interestShown.ResponseStatus);
                para.Add("@Message", interestShown.Message);

            }
            catch (Exception exp)
            {
                msg = "Error :" + exp.Message;
            }
            try
            {
                sqlHelper.ExecuteSp("InsertUserInterestShown", para, null, true, null);
                msg = "Successfully Inserted Request.";
            }
            catch (Exception exp)
            {
                msg = "Error :" + exp.Message;
            }
            return msg;
        }
    }
}

//Test Json
/*

    {
"firstName": "sumit",
"lastName": "joshi",
"landline": "01127850127",
"gender": "Married",
"maritalstatus": "D",
"gotra": "Kaushik",
"dob": {
"date": {
             "year" : "2017",
             "month"  : "12", 
             "day" : "24"
         },
"jsdate": "",
"formatted": "",
"epoc" :""
},
"time": {
"hh": "12",
"min": "1",
"sec": "49"
},
"birthplace": "Delhi",
"email": "a113812@a.com",
"password": "12234",
"confirmPassword": "",
"height": "5.7",
"weight": "84",
"incomerange": "10000-20000",
"smokestatus": "Yes",
"dietstatus": "Veg",
"workstatus": "job",
"drinkstatus": "No",
"religion": "Hindu",
"mothertounge": "Hindi",
"rashi": "5",
"education": "MBA",
"profession": "Job",
"address": "Roihini",
"country": "india",
"city": "delhi",
"place": "delhi",
"zip": "110089",
"about": "about me",
"mySubCaste": "joshi",
"recaptcha": "",
"mobile":"9650899699"
}
*/
