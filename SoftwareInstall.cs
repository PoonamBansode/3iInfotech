﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Cognitive.LUIS.ActionBinding;
using RestSharp;

namespace LuisBot.Dialogs
{
    [Serializable]
    [LuisActionBinding("Software Install", FriendlyName = "Software Install")]
    public class SoftwareInstall : BaseLuisAction
    {
        [Required(ErrorMessage = "Sure, I'll help you to install software. Please  help me with your system’s IP address.")]
        [LuisActionBindingParam(CustomType = "hostIP", Order = 1)]
        //CustomType/BuiltinType = (Entity name in LUIS)
        public string hostIP { get; set; }


        
        [Required(ErrorMessage = "Thanks! I can help you with these software installation. Please select one of the software below.\"< br ><input type = 'button' class='button' id='notepad++' value='Notepad++' onclick=\"button_send('Notepad++');\"/><input type = 'button' class='button' id='adobe_reader' value='Adobe Reader' onclick=\"button_send('Adobe Reader');\"/><input type = 'button' class='button' id='nodejs' value='Node.js' onclick=\"button_send('Node.js');\"/>")]
        [LuisActionBindingParam(CustomType = "software", Order = 1)]
        //CustomType/BuiltinType = (Entity name in LUIS)
        public string software { get; set; }


        public override Task<object> FulfillAsync()
        {
            Dictionary<string, string> MyEntities = new Dictionary<string, string>();

            MyEntities.Add("hostIP", this.hostIP);
            MyEntities.Add("SoftwareName", this.software);

            CreateJSON createJSON = new CreateJSON();


            string aeRequestId;
            aeRequestId = createJSON.AECall(MyEntities, "Software Installation");
            //GetStatus getStatus = new GetStatus();
            //Thread.Sleep(15000);
            //string response = getStatus.GetStatusAECall(aeRequestId);



            return Task.FromResult((object)$"Please wait while we work on your request.");
            //return Task.FromResult((object)$"Please wait while we work on your request. It typically takes 2 minutes to complete the operation, click after 2 minutes.< input type = 'button' class='button' id='check_status' value='Click here to check status' onclick=\"button_send('Check Status');\"/>");

        }
     }

}

