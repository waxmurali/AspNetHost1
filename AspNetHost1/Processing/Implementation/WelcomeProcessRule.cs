using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspNetHost1.Models;

namespace AspNetHost1.Processing.Implementation
{
    public class WelcomeProcessRule : IProcessRule
    {
        public bool IsRequestTextMatch(string stext)
        {
            return stext.ToLower().Trim() == "web3";
        }

        public string ProcessRequest(QueryRequestJsonModel request, ILogWriter logWriter)
        {
            return $"Hi welcome to {request.Result.Parameters.EntityText} world";
        }
    }
}