using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DocOperator.Common;
using Serilog;

namespace DocOperator.OfficeOper
{
    class OfficeConverter
    {
        static public bool ToPDF(string sourcePath, string targetPath)
        {
            string exe = Utility.getExePath() + "OfficeToPDF.exe";
            string param = "\"" + sourcePath + "\" " + targetPath + "\"";
            string result = Utility.RunCmd(exe, param, 30 * 1000);

            if (result.Length > 0)
            {
                Log.Information(result);
            }

            // 检查文件是否生成

            return File.Exists(targetPath);
        }
    }

}
