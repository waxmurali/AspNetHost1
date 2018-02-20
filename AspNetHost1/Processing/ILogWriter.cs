using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetHost1.Processing
{
    public interface ILogWriter
    {
        void LogMessage(string message);
    }
}
