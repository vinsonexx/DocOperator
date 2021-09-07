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
        protected int waitTime;

        public Worker()
        {
            dbOper = new DbOper();

            string configFile = Utility.getExePath() + "config.ini";
            CfgInfo cfgInfo = new CfgInfo(configFile);
            projectDir = cfgInfo.GetProjectDir();
            waitTime = cfgInfo.GetWaitTime();
        }

    }
}
