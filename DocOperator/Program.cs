using System;
using System.Threading;
using Serilog;
using DocOperator.Common;
using DocOperator.Logic;

namespace DocOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            string logfile = Utility.getExePath() + "DocOperator.log";
            Logger.InitLogger(logfile);

            Log.Information("DocOperator start...");

            Thread t = new Thread(ConvertThread);
            t.Start();

            t = new Thread(SignThread);
            t.Start();
            t.Join();
        }


        static void ConvertThread()
        {
            ConvertWorker w = new ConvertWorker();
            w.StartUp();
        }

        static void SignThread()
        {
            SignWorker w = new SignWorker();
            w.StartUp();
        }

    }
}
