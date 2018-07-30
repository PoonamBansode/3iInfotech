using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Cognitive.LUIS.ActionBinding;
using Newtonsoft.Json.Linq;

namespace LuisBot.Dialogs
{
    [Serializable]
    [LuisActionBinding("Enter OTP", FriendlyName = "Enter OTP")]
    public class EnterOTP : BaseLuisAction
    {
        [Required(ErrorMessage = "Please Enter your OTP")]
        [LuisActionBindingParam(CustomType = "OTP", Order = 1)]
        //CustomType/BuiltinType = (Entity name in LUIS)
        public string OTP { get; set; }


        public override Task<object> FulfillAsync()
        {
            string result;

            if (OTP.ToUpper().Equals(ResetUserPassword.otp))
            {
                Dictionary<string, string> MyEntities = new Dictionary<string, string>();
                MyEntities.Add("User_Logon_Name", ResetUserPassword.username);
                //MyEntities.Add("User_Logon_Name", "Geetanjali Khyale");
                MyEntities.Add("aewfid", "198");
                MyEntities.Add("MobileNumber", ResetUserPassword.phoneno);
                //MyEntities.Add("MobileNumber", "919730975520");

                CreateJSON createJSON = new CreateJSON();

                string aeRequestId;
                aeRequestId = createJSON.AECall(MyEntities, "Reset Password");//Call Automation Edge.

                //return Task.FromResult((object)$"{ResetUserPassword.username} \n {ResetUserPassword.phoneno} \n {ResetUserPassword.otp}Your request for reset password has been initiated and password is sent on your registered mobile number.\n Was I helpful?");
                result = $"Username: {ResetUserPassword.username} \n Phoneno: {ResetUserPassword.phoneno} \n OTP: {ResetUserPassword.otp} \n Your request for reset password has been initiated and password is sent on your registered mobile number.\n Was I helpful?";
            }
            else
            {
                result = $"OTP didn't match";

            }

            


            //return Task.FromResult((object)$"Password is reset... Visit me again whenever you need my help. Have a great day :)");
            return Task.FromResult((object)result);
        }
        
    }


}