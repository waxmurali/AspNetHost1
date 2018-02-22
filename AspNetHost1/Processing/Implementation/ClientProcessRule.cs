using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspNetHost1.Models;

namespace AspNetHost1.Processing.Implementation
{
    public class ClientProcessRule : IProcessRule
    {
        public bool IsRequestTextMatch(string stext)
        {
            return stext.ToLower().Trim() == "clients";
        }

        public string ProcessRequest(QueryRequestJsonModel request, ILogWriter logWriter)
        {
            return "200 clients are using web3 at the moment";
        }
    }
}