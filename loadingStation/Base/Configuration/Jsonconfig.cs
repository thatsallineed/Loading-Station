using System;
using System.Diagnostics;
using Newtonsoft.Json;

using loadingStation.Base.Function;

namespace loadingStation.Base.Configuration
{
    class Conf
    {
        // Database
        public string Host;
        public string Database;
        public string Username;
        public string Password;

        // Application
        public bool IsDebugging;
        public bool IndicatorTestOnly;
        public bool LoginUseAuthentication;

        // Modbus
        public string ModbusInput;
        public string ModbusOutput;

        // Socket
        public string SocketClientHost;
    }
    public class Jsonconfig
    {
        public static void Loadconfig()
        {
            string json = Actions.FileToString("config.json");

            if (json != "")
            {
                Conf config = JsonConvert.DeserializeObject<Conf>(json);

                GlobalProperties.Configuration.DatabaseHost = config.Host;
                GlobalProperties.Configuration.DatabaseDB = config.Database;
                GlobalProperties.Configuration.DatabaseUsername = config.Username;
                GlobalProperties.Configuration.DatabasePassword = config.Password;

                GlobalProperties.Configuration.IsDebugging = config.IsDebugging;
                GlobalProperties.Configuration.IndicatorOnly = config.IndicatorTestOnly;
                GlobalProperties.Configuration.LoginUseAuthentication = config.LoginUseAuthentication;

                GlobalProperties.Configuration.ModbusDebugInput = config.ModbusInput;
                GlobalProperties.Configuration.ModbusDebugOutput = config.ModbusOutput;

                GlobalProperties.Configuration.SocketClientHost = config.SocketClientHost;
                
                Debug.WriteLine("Loaded Json Config");
            }
            else
            {
                GenerateConfig();
                Debug.WriteLine("Json Config Not Loaded, Autogenerate");
                Loadconfig();
            }
        }

        public static void GenerateConfig()
        {
            Conf config = new Conf
            {
                Host = GlobalProperties.Configuration.DatabaseHost,
                Database = GlobalProperties.Configuration.DatabaseDB,
                Username = GlobalProperties.Configuration.DatabaseUsername,
                Password = GlobalProperties.Configuration.DatabasePassword,

                IsDebugging = GlobalProperties.Configuration.IsDebugging,
                IndicatorTestOnly = GlobalProperties.Configuration.IndicatorOnly,
                LoginUseAuthentication = GlobalProperties.Configuration.LoginUseAuthentication,
                ModbusInput = GlobalProperties.Configuration.ModbusDebugInput,
                ModbusOutput = GlobalProperties.Configuration.ModbusDebugOutput,
                SocketClientHost = GlobalProperties.Configuration.SocketClientHost
            };

            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            Actions.StringToFile("config.json", json);
            Debug.WriteLine("Write config.json OK");
        }
    }
}
