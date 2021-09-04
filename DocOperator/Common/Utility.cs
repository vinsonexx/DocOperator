using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DocOperator.Common
{
    class Utility
    {
        static public string getExePath()
        {
            string exePath = Process.GetCurrentProcess().MainModule.FileName;
            int pos = exePath.LastIndexOf('\\');
            if (pos > 0)
            {
                return exePath.Substring(0, pos + 1);
            }

            return "";
        }

    }
}
