using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace DocOperator.Common
{
    class Utility
    {
        public static string getExePath()
        {
            string exePath = Process.GetCurrentProcess().MainModule.FileName;
            int pos = exePath.LastIndexOf('\\');
            if (pos > 0)
            {
                return exePath.Substring(0, pos + 1);
            }

            return "";
        }

        public static string RunCmd(string exe, string param, int milliseconds)
        {
            if (!File.Exists(exe))
            {
                return "error";
            }

            Process p = new Process();

            p.StartInfo.FileName = exe;                 // 程序名
            p.StartInfo.Arguments = param;              // 参数
            p.StartInfo.UseShellExecute = false;        // 关闭Shell的使用
            p.StartInfo.RedirectStandardInput = true;   // 重定向标准輸入
            p.StartInfo.RedirectStandardOutput = true;  // 重定向标准輸出
            p.StartInfo.RedirectStandardError = true;   // 重定向错误輸出
            p.StartInfo.CreateNoWindow = true;          // 不显示窗口
                                                        
            p.Start();  // 启动
            p.WaitForExit(milliseconds);

            return p.StandardOutput.ReadToEnd();        //从输出流取得命令执行結果    
        }

        public static string GetBackupFilePath(string srcFilePath)
        {
            string ext = Path.GetExtension(srcFilePath);
            return srcFilePath.Substring(0, srcFilePath.Length - ext.Length) + 
                "_bk" + ext;
        }


    }
}
