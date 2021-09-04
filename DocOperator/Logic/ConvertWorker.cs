using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocOperator.Model;
using DocOperator.Common;
using DocOperator.OfficeOper;
using System.Threading;

namespace DocOperator.Logic
{
    class ConvertWorker
    {
        public void StartUp()
        {
            DbOper dbOper = new DbOper();
            string configFile = Utility.getExePath() + "config.ini";
            CfgInfo cfgInfo = new CfgInfo(configFile);
            string projetDir = cfgInfo.GetProjectDir();
            int waitTime = 15 * 1000;

            for (;;)
            {
                List<File> fileList = dbOper.GetPendingTask();              
                foreach (var file in fileList)
                {
                    if (convertFile(projetDir +  file.path))
                    {
                        dbOper.SetDocumentConverted(file.documentId);
                    }
                }

                Thread.Sleep(waitTime);     // 避免失败文件循环 
            }
        }


        private bool convertFile(string srcFile)
        {
            srcFile = srcFile.Replace('/', '\\');
            if (!System.IO.File.Exists(srcFile))
            {
                return false;
            }

            int pos = srcFile.LastIndexOf('.');
            if (pos <= 0)
                return false;

            string destFile = srcFile.Substring(0, pos) + ".pdf";
            return WordOper.WordToPDF(srcFile, destFile);
        }


    }
}
