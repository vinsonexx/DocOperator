﻿using System;
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

            ConvertWorker w = new ConvertWorker();
            w.StartUp();
        }

    }
}
