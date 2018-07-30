﻿using System;
using System.Configuration;
using System.Threading.Tasks;
using RestSharp;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using LuisBot.Dialogs;
using Microsoft.Cognitive.LUIS.ActionBinding.Bot;
using System.Reflection;

namespace Microsoft.Bot.Sample.LuisBot
{
    // For more information about this template visit http://aka.ms/azurebots-csharp-luis
    [Serializable]
    public class BasicLuisDialog : LuisActionDialog<object>
    {
        //string SenderId;
        //string SenderName;
        

        public BasicLuisDialog() : base(
       new Assembly[] { typeof(GreetingAction).Assembly },
       (action, context) =>
       {
       },
            new LuisService(new LuisModelAttribute(
            ConfigurationManager.AppSettings["LUIS_ModelId"],
            ConfigurationManager.AppSettings["LUIS_SubscriptionKey"],
        domain: ConfigurationManager.AppSettings["LuisAPIHostName"])))
        {
        }


        [LuisIntent("Greeting")]
        public async Task IntentGreetingHandlerAsync(IDialogContext context, object actionResult)
        {
            var message = context.MakeMessage();
            message.Text = actionResult != null ? actionResult.ToString() : "Cannot resolve your query";
            await context.PostAsync(message);
        }

        [LuisIntent("Create AD User")]
        public async Task IntentCreateADUserHandlerAsync(IDialogContext context, object actionResult)
        {
            //string data = context.Activity.ToString();
            //SenderId = context.Activity.From.Id;
            //SenderName = context.Activity.From.Name;

            var message = context.MakeMessage();
          
            message.Text = actionResult != null ? actionResult.ToString() : "Cannot resolve your query";
            await context.PostAsync(message);
        }


        //[LuisIntent("Cancel")]
        //public async Task IntentCancelHandlerAsync(IDialogContext context, object actionResult)
        //{
        //    var message = context.MakeMessage();
        //    message.Text = actionResult != null ? actionResult.ToString() : "Cannot resolve your query";
        //    await context.PostAsync(message);

        //}

        //[LuisIntent("Help")]
        //public async Task IntentHelpHandlerAsync(IDialogContext context, object actionResult)
        //{
        //    var message = context.MakeMessage();
        //    message.Text = actionResult != null ? actionResult.ToString() : "Cannot resolve your query";
        //    await context.PostAsync(message);
        //    await context.PostAsync("You may say something like this : 'Add ad user' , 'Please unlock ad user' , 'Take a snap' , 'Add VM'");
        //}

        //[LuisIntent("None")]
        //public async Task IntentNoneHandlerAsync(IDialogContext context, object actionResult)
        //{
        //    var message = context.MakeMessage();
        //    message.Text = actionResult != null ? actionResult.ToString() : "Cannot resolve your query";
        //    await context.PostAsync(message);
        //    await context.PostAsync("You may say something like this : 'Add ad user' , 'Please unlock ad user' , 'Take a snap' , 'Add VM'");
        //}

        [LuisIntent("Internet is not working")]
        public async Task IntentInternetisnotworkingHandlerAsync(IDialogContext context, object actionResult)
        {
            var message = context.MakeMessage();
            
            message.Text = actionResult != null ? actionResult.ToString() : "Cannot resolve your query";
            await context.PostAsync(message);
        }

        [LuisIntent("Reset User Password")]
        public async Task IntentResetUserPasswordHandlerAsync(IDialogContext context, object actionResult)
        {
            var message = context.MakeMessage();
            message.Text = actionResult != null ? actionResult.ToString() : "Cannot resolve your query";
            await context.PostAsync(message);
        }

        [LuisIntent("Enter OTP")]
        public async Task IntentEnterOTPHandlerAsync(IDialogContext context, object actionResult)
        {
            var message = context.MakeMessage();
            message.Text = actionResult != null ? actionResult.ToString() : "Cannot resolve your query";
            await context.PostAsync(message);
        }

        [LuisIntent("Shared Folder Access")]
        public async Task IntentSharedFolderAccessHandlerAsync(IDialogContext context, object actionResult)
        {
            var message = context.MakeMessage();
            message.Text = actionResult != null ? actionResult.ToString() : "Cannot resolve your query";
            await context.PostAsync(message);

        }

        [LuisIntent("Software Install")]
        public async Task IntentCheckIncidentStatusActionResultHandlerAsync(IDialogContext context, object actionResult)
        {
            var message = context.MakeMessage();
            message.Text = actionResult != null ? actionResult.ToString() : "Cannot resolve your query";
            await context.PostAsync(message);
        }

        //[LuisIntent("Check Incident Status")]
        //public async Task IntentCheckIncidentStatusActionResultHandlerAsync(IDialogContext context, object actionResult)
        //{
        //    var message = context.MakeMessage();
        //    message.Text = actionResult != null ? actionResult.ToString() : "Cannot resolve your query";
        //    await context.PostAsync(message);
        //}

        //[LuisIntent("Create Incident")]
        //public async Task IntentCIncidentActionResultHandlerAsync(IDialogContext context, object actionResult)
        //{
        //    var message = context.MakeMessage();
        //    message.Text = actionResult != null ? actionResult.ToString() : "Cannot resolve your query";
        //    await context.PostAsync(message);
        //}
    }

    public class MyDetail
    {
        public string sessionToken
        {
            get;
            set;
        }
    }
}
