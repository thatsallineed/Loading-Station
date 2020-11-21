using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loadingStation.Base.Configuration
{
    class Logs
    {
        public static bool IsLogEnabled
        {
            get { return Config.Logs.Default.IsLogEnabled; }
        }
        public static string LastlogTime
        {
            get { return Config.Logs.Default.LastlogTime.ToString(); }
        }
        public static int SaveLogDuration
        {
            get { return Config.Logs.Default.SaveLogDuration; }
            set { Config.Logs.Default.SaveLogDuration = value; }
        }


        public static void SetLogEnabled()
        {
            Config.Logs.Default.IsLogEnabled = true;
            Config.Logs.Default.Save();
        }
        public static void SetLogDisabled()
        {
            Config.Logs.Default.IsLogEnabled = false;
            Config.Logs.Default.Save();
        }
        public static void SetLastlog()
        {
            var datenow = DateTime.Now.ToString("dd/MM/YYYY - HH:mm:ss");
            Config.Logs.Default.LastlogTime = datenow;
            Config.Logs.Default.Save();
        }
    }
}
