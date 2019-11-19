using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcardCrawler
{
    public class Intial
    {
        public Intial() { }

        public static void Log(string name)
        {
            Serilog.Log.Logger = new LoggerConfiguration().WriteTo.File(AppDomain.CurrentDomain.BaseDirectory + name, rollingInterval: RollingInterval.Day).CreateLogger();
        }
    }
}
