using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;

namespace DocOperator.Common
{
    class CfgInfo
    {
        private string cfgFile;
        private string section = "Set";

        public CfgInfo(string filePath)
        {
            cfgFile = filePath;
        }

        public string GetConnString()
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(cfgFile);

            return data[section]["ConnectString"];
        }

        public string GetProjectDir()
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(cfgFile);

            return data[section]["ProjectDir"];
        }





    }
}
