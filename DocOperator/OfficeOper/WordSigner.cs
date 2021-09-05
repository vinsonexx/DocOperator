using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocOperator.Vo;
using Newtonsoft.Json;
using System.IO;
using DocOperator.Common;
using Serilog;


namespace DocOperator.OfficeOper
{
    class WordSigner
    {
        // 生成JSON文件，并调用Python程序
        static public bool Sign(int docId, SignConfig config)
        {
            System.IO.File.Copy(config.srcPath,
                Utility.GetBackupFilePath(config.srcPath), true);

            // 生成json文件
            string jsonStr = JsonConvert.SerializeObject(config);
            string jsonDir = Utility.getExePath() + "json\\";
            string jsonFile = jsonDir + docId.ToString() + ".json";
            Directory.CreateDirectory(jsonDir);
            writeJsonFile(jsonFile, jsonStr);

            string exe = Utility.getExePath() + "WordOper.exe";
            string result = Utility.RunCmd(exe, jsonFile, 30 * 1000);

            Log.Information(result);
            return true;
        }

        static private void writeJsonFile(string path, string jsonConents)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine(jsonConents);
                }
            }
        }



    }
}
