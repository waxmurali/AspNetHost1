using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspNetHost1.Models;

namespace AspNetHost1.Processing.Implementation
{
    public class DefaultProcessRule : IProcessRule
    {
        public bool IsRequestTextMatch(string stext)
        {
            return stext.ToLower().Trim() != "web3" || stext.ToLower().Trim() != "clients" ||
                   stext.ToLower().Trim() != "users";
        }

        public string ProcessRequest(QueryRequestJsonModel request, ILogWriter logWriter)
        {
            return "Sorry, I could not process your request. Please try again.";
        }
    }
}