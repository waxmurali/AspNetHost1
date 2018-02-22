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
        private List<IProcessRule> _processRules;

        public ProcessRequest()
        {
            _processRules = new List<IProcessRule>();    
            _processRules.Add(new WelcomeProcessRule());
            _processRules.Add(new UserProcessRule());
            _processRules.Add(new ClientProcessRule());
            _processRules.Add(new DefaultProcessRule());
        }

        public DialogflowResponseV1 ProcessRequestForQuery(QueryRequestJsonModel request,ILogWriter logWriter)
        {
            logWriter.LogMessage("Handle Request");

            var responseText =
                _processRules.First(r => r.IsRequestTextMatch(request.Result.Parameters.EntityText))
                    .ProcessRequest(request, logWriter);
            //foreach (var processRule in _processRules)
            //{
            //    if (processRule.IsRequestTextMatch(request.Result.Parameters.EntityText))
            //        responseText = processRule.ProcessRequest(request, logWriter);
            //}
            ////var restext = _processRules.ForEach(c => c.IsRequestTextMatch(request.Result.Parameters.EntityText)).

            
            //switch (request.Result.Parameters.EntityText.ToLower())
            //{
            //    case "web3":
            //        responseText = getWelcomeText(request);
            //        break;
            //    case "users":
            //        responseText = getUsersText(request);
            //        break;
            //    case "clients":
            //        responseText = getClientsText(request);
            //        break;
            //    default:
            //        responseText = "Sorry, I could not process your request. Please try again.";
            //        break;
            //}


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