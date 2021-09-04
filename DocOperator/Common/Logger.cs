using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace DocOperator.Common
{
    class Logger
    {
        static public void InitLogger(string filePath)
        { 
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(filePath, rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7)
                .CreateLogger();
        }
    }
}
