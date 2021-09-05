using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocOperator.Common;

namespace DocOperator.Logic
{
    class Worker
    {
        protected DbOper dbOper;
        protected string projectDir;
        protected const int waitTime = 15 * 1000;

        public Worker()
        {
            dbOper = new DbOper();

            string configFile = Utility.getExePath() + "config.ini";
            CfgInfo cfgInfo = new CfgInfo(configFile);
            projectDir = cfgInfo.GetProjectDir();
        }

    }
}
