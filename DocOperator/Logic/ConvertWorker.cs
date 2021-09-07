using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Serilog;
using DocOperator.Model;
using DocOperator.Common;
using DocOperator.OfficeOper;


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
                        Log.Information(string.Format("ConvetFile({0}{1}) success. "), projectDir, doc.path);
                        dbOper.SetDocumentStep(doc.id, doc.step + 1);
                    }
                    else
                    {
                        Log.Information(string.Format("ConvetFile({0}{1}) failed. "), projectDir, doc.path);
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

            string extFileName = System.IO.Path.GetExtension(srcFile);
            string destFile = srcFile.Substring(0, srcFile.Length - extFileName.Length) + ".pdf";
            return OfficeConverter.ToPDF(srcFile, destFile);
        }


    }
}
