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
    }
}