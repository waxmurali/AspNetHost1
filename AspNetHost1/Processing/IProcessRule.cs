using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetHost1.Models;

namespace AspNetHost1.Processing
{
    public interface IProcessRule
    {
        bool IsRequestTextMatch(string stext);
        string ProcessRequest(QueryRequestJsonModel request,ILogWriter logWriter);
    }
}
