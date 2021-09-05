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
    class ConvertWorker : Worker
    {
        public void StartUp()
        {
            for (;;)
            {
                var docList = dbOper.GetConvertTask();
                foreach (var doc in docList)
                {
                    if (convertFile(projectDir +  doc.path))
                    {
                        dbOper.SetDocumentStep(doc.id, doc.step + 1);
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
            return WordConverter.ToPDF(srcFile, destFile);
        }


    }
}
