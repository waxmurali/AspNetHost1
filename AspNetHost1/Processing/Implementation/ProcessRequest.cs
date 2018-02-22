using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using AspNetHost1.Models;
using TestNancy.Models;

namespace AspNetHost1.Processing.Implementation
{
    public class ProcessRequest : IProcessRequest
    {

        public DialogflowResponseV1 ProcessRequestForQuery(QueryRequestJsonModel request,ILogWriter logWriter)
        {
            logWriter.LogMessage("Handle Request");

            string responseText;
            switch (request.Result.Parameters.EntityText.ToLower())
            {
                case "web3":
                    responseText = getWelcomeText(request);
                    break;
                case "users":
                    responseText = getUsersText(request);
                    break;
                case "clients":
                    responseText = getClientsText(request);
                    break;
                default:
                    responseText = "Sorry, I could not process your request. Please try again.";
                    break;
            }


            var response = new DialogflowResponseV1
            {
                Speech = responseText,
                DisplayText = responseText,
                Source = "Webhook Service",
                Data = new Data(),
                ContextOut = new Context[0]
            };

            return response;
        }

        private string getClientsText(QueryRequestJsonModel request)
        {
            return "200 clients are using web3 at the moment";
        }

        private string getUsersText(QueryRequestJsonModel request)
        {
            string responseText;
            switch (request.Result.Parameters.PeriodRange.ToLower().Trim())
            {
                case "last week":
                    responseText = "There were 20 users logged in last week";
                    break;
                case "month":
                    responseText = "There were 50 users logged into web3 this month";
                    break;
                default:
                    responseText = "Sorry, I could only process for last week and this month";
                    break;
            }
            return responseText;
        }

        private string getWelcomeText(QueryRequestJsonModel request)
        {
            return $"Hi welcome to {request.Result.Parameters.EntityText} world";
        }
    }
}