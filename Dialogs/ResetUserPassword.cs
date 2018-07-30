using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Cognitive.LUIS.ActionBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LuisBot.Dialogs
{
   

    [Serializable]
    [LuisActionBinding("Reset User Password", FriendlyName = "Reset User Password Service Request")]
    public class ResetUserPassword : BaseLuisAction
    {
        public static string username;
        public static string phoneno;
        public static string otp;

        [Required(ErrorMessage = "Please give me your user name")]
        [LuisActionBindingParam(CustomType = "adusername", Order = 1)]
        //CustomType/BuiltinType = (Entity name in LUIS)
        public string adusername { get; set; }

        [Required(ErrorMessage = "Please enter your phone number below")]
        [LuisActionBindingParam(BuiltinType = BuiltInTypes.Phonenumber, Order = 2)]
        public string phonenumber { get; set; }


        public override Task<object> FulfillAsync()
        {
            Dictionary<string, string> MyEntities = new Dictionary<string, string>();

            MyEntities.Add("username", this.adusername);   //Workflow parameter
            MyEntities.Add("mobile", this.phonenumber);    //Workflow parameter

            CreateJSON createJSON = new CreateJSON(); //instance created for createjson

            string aeRequestId; //variable creation for ae call
            aeRequestId = createJSON.AECall(MyEntities, "Generate OTP");  // ae call
            

            GetStatus getStatus = new GetStatus();   //instance created of GetStatus
            Thread.Sleep(15000); // Wait for workflow execution
            string response = getStatus.GetStatusAECall(aeRequestId); //Get Status Response - response from ae.

            var rss = JObject.Parse(response);      // JObject.Parse string is converting in json format.
            username = (string)rss["attribute1"];   // username is stored in attribute1 field of response.
            phoneno = (string)rss["attribute2"];    // phoneno is stored in attribute2 field of response.
            otp = (string)rss["attribute3"];        // otp is stored in attribute3 field of response.




            //return Task.FromResult((object)$"I will reset password for  {this.adusername} as soon as possible... Visit me again whenever you need my help. Have a great day :)");

            return Task.FromResult((object)$"{username} OTP is sent on your registered mobile number, please enter otp. Your reference key is - {aeRequestId} (RK). You need to enter reference key<space>OTP eg. (RK) AZ6754");
            //Get Status Response from ae

        }
    }
}