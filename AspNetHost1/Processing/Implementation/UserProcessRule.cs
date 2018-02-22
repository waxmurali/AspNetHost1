using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspNetHost1.Models;

namespace AspNetHost1.Processing.Implementation
{
    public class UserProcessRule : IProcessRule
    {
        public bool IsRequestTextMatch(string stext)
        {
            return stext.ToLower().Trim() == "users";
        }

        public string ProcessRequest(QueryRequestJsonModel request, ILogWriter logWriter)
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
    }
}