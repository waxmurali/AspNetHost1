using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetHost1.Models;
using TestNancy.Models;

namespace AspNetHost1.Processing
{
    public interface IProcessRequest
    {
        DialogflowResponseV1 ProcessRequestForQuery(QueryRequestJsonModel request,ILogWriter logWriter);
    }
}
