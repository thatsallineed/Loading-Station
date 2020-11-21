using loadingStation.Base.Function;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Data;
using System.Runtime.Remoting.Messaging;

namespace loadingStation.Base.Connection.Database
{
    internal class DB_SFDB
    {
        #region Private Properties
        private static DataTable dtUser = new DataTable();
        #endregion

        /// <summary>
        /// Function For Reading MySql sfdb.mst_user to bool
        /// </summary>
        public static bool LoginAuthentication(string nrp)
        {
            bool result = false;
            string query = string.Format("SELECT * FROM mst_user WHERE BINARY nrp= '{0}'", nrp);

            using (MySqlConnection conn = new MySqlConnection())
            {
                Database.OpenConnection(conn);
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            result = true;
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Function For Reading MySql sfdb.mst_user to bool
        /// </summary>
        public static bool LoginAuthenticationRestart(string nrp)
        {
            bool result = false;
            string query = string.Format("SELECT * FROM mst_user WHERE BINARY nrp= '{0}' AND level=4", nrp);

            using (MySqlConnection conn = new MySqlConnection())
            {
                Database.OpenConnection(conn);
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            result = true;
                        }
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// Function For Read Message from trx_loadingstation_message
        /// </summary>
        /// <returns>Message</returns>
        public static bool GetLoadingstationMessage(out string Message, out bool IsError)
        {
            bool result = false;

            Message = "";
            IsError = false;

            string query = $"SELECT * FROM mst_loadingstation_message WHERE coolant_type='{GlobalProperties.CoolantType}' AND changed=0 AND logdate >= CURRENT_TIMESTAMP - INTERVAL 5 SECOND";

            using (MySqlConnection conn = new MySqlConnection())
            {
                Database.OpenConnection(conn);
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            Message = reader.GetString("description");
                            bool.TryParse(reader.GetString("is_failure"), out IsError);
                            result = true;

                            UpdateMessageStatus();
                        }
                    }
                }
            }

            return result;
        }


        /// <summary>
        /// Function For Read List Message Loadingstation Error, then alert rotator
        /// </summary>
        public static bool GetLoadingStationErrorMessageRotator()
        {
            bool result = false;

            string query = $"SELECT * FROM mst_loadingstation_message WHERE is_failure=1 AND logdate >= CURRENT_TIMESTAMP - INTERVAL 5 SECOND";

            using (MySqlConnection conn = new MySqlConnection())
            {
                Database.OpenConnection(conn);
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            result = true;
                        }
                    }
                }
            }

            return result;
        }


        /// <summary>
        /// Function For Update Message Status Changed
        /// </summary>
        public static void UpdateMessageStatus()
        {
            string query = $"UPDATE mst_loadingstation_message SET changed=1 WHERE coolant_type='{GlobalProperties.CoolantType}'";
            Database.InsertToMySql(query);
        }

        /// <summary>
        /// Function For Reading Mysql sfdb.trx_tasklist to DataTable
        /// </summary>
        public static DataTable PopulateTasklist()
        {
            string Now = DateTime.Now.ToString("yyyy-MM-dd");
            char coolanttype = Function.GlobalProperties.CoolantType;
            string query = string.Format("SELECT * FROM trx_coolant_tasklist WHERE date_time LIKE '{0}%' ORDER BY date_time ASC", Now, coolanttype.ToString());

            return Database.MySqlToDataTable(query);
        }


        /// <summary>
        /// Function For Reading Mysql sfdb.mst_user to DataTable
        /// </summary>
        public static DataTable PopulateUser()
        {
            string query = "SELECT * FROM mst_user";
            dtUser = Database.MySqlToDataTable(query);
            return dtUser;
        }


        /// <summary>
        /// Function For Reading Mysql trx_history_loading to DataTable
        /// </summary>
        public static DataTable PopulateHistory(char typecoolant)
        {
            string query = string.Format("SELECT id AS ID, coolant_type as Type, nrp AS NRP, createddate as Date FROM mst_history_loading WHERE coolant_type = '{0}' order by id desc limit 0, 14", typecoolant);
            return Database.MySqlToDataTable(query);
        }


        /// <summary>
        /// Function For Reading Mysql machine to DataTable
        /// </summary>
        public static string[] PopulateOverview(string idbarcode)
        {
            string query = string.Format("SELECT * FROM machine WHERE id_barcode=\"{0}\"", idbarcode);
            string[] result = null;

            using (MySqlConnection conn = new MySqlConnection())
            {
                Database.OpenConnection(conn);
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            result[0] = reader.GetString("name");
                            result[1] = reader.GetString("op");
                            result[2] = reader.GetString("status");
                        }
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// Function For Insert Mysql sfdb.mst_history_loading
        /// </summary>
        public static void InsertHistoryLoading(string UserId, char CoolantType, string Datenow)
        {
            string query = $"INSERT INTO `mst_history_loading` (`id`, `nrp`, `coolant_type`, `createddate`) VALUES (NULL, '{UserId}', '{CoolantType}', '{Datenow}');";

            using (MySqlConnection conn = new MySqlConnection())
            {
                Database.OpenConnection(conn);
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Function For Reading Mysql sfdb.mst_serialnumber to Boolean
        /// </summary>
        public static bool CheckSerialNumber(string SerialByte)
        {
            string query = string.Format("SELECT serialnumber FROM mst_serialnumber where serialnumber=\"{0}\"", SerialByte);
            bool result = false;

            using (MySqlConnection conn = new MySqlConnection())
            {
                Database.OpenConnection(conn);
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            result = true;
                        }
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// Function For Reading Mysql mst_loading_station
        /// </summary>
        public static string IpDigitalInput()
        {
            string result = "";
            var coolanttype = Function.GlobalProperties.CoolantType;
            string query = string.Format("SELECT ipdigitalinput FROM mst_loading_station WHERE coolant_type='{0}';", coolanttype);

            using (MySqlConnection conn = new MySqlConnection())
            {
                Database.OpenConnection(conn);
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            result = reader.GetString("ipdigitalinput");
                        }
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// Function For Reading Mysql mst_loading_station
        /// </summary>
        public static void Pulse(out double CoolantPulse)
        {
            CoolantPulse = 0;
            
            var coolanttype = Function.GlobalProperties.CoolantType;
            string query = string.Format("SELECT coolant_pulse FROM mst_loading_station WHERE coolant_type='{0}';", coolanttype);

            using (MySqlConnection conn = new MySqlConnection())
            {
                Database.OpenConnection(conn);
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            CoolantPulse = double.Parse(reader.GetString("coolant_pulse"));
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Function For Update Pulse Value
        /// </summary>
        /// <param name="WaterPulse"></param>
        /// <param name="CoolantPulse"></param>
        public static void UpdatePulse(double CoolantPulse)
        {
            Database.InsertToMySql($"UPDATE mst_loading_station SET coolant_pulse={CoolantPulse} WHERE coolant_type='{GlobalProperties.CoolantType}';");
        }


        /// <summary>
        /// Function For Reading Mysql sfdb.mst_loading_station
        /// </summary>
        public static string IpDigitalOutput()
        {
            string result = "";
            var coolanttype = Function.GlobalProperties.CoolantType;
            string query = string.Format("SELECT ipdigitaloutput FROM mst_loading_station WHERE coolant_type='{0}';", coolanttype);

            using (MySqlConnection conn = new MySqlConnection())
            {
                Database.OpenConnection(conn);
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            result = reader.GetString("ipdigitaloutput");
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Function For Reading Mysql mst_loading_station
        /// </summary>
        public static string IpDigitalPulse()
        {
            string result = "";
            var coolanttype = Function.GlobalProperties.CoolantType;
            string query = string.Format("SELECT ipdigitalpulse FROM mst_loading_station WHERE coolant_type='{0}';", coolanttype);

            using (MySqlConnection conn = new MySqlConnection())
            {
                Database.OpenConnection(conn);
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            result = reader.GetString("ipdigitalpulse");
                        }
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// Function For GET ID mysql sfdb.mst_detail_loading
        /// </summary>
        public static int GetIdDetailLoading(int CH)
        {
            int result = 0;
            string IP = Function.GlobalProperties.ModbusInput.IpAddress;
            string query = string.Format("SELECT id FROM mst_detail_loading WHERE channel = {0} AND ipaddress = '{1}'", CH, IP);

            using (MySqlConnection conn = new MySqlConnection())
            {
                Database.OpenConnection(conn);
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            result = (int)reader["id"];
                        }
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// Function For GET Max & Min Value sfdb.mst_detail_loading
        /// </summary>
        public static int[] GetDetailLoadingMaxMinValue(int channel)
        {
            int[] result = null;

            string query = string.Format("SELECT min_value,max_value FROM mst_detail_loading WHERE channel = {0}", channel);

            using (MySqlConnection conn = new MySqlConnection())
            {
                Database.OpenConnection(conn);
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            result[0] = (int)reader["max_value"];
                            result[1] = (int)reader["min_value"];
                        }
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// Function For Get Pump Status,Updatedate sfdb.mst_loading_station
        /// </summary>
        public static int GetPumpStatus()
        {
            int result = 0;

            char coolanttype = Function.GlobalProperties.CoolantType;
            string query = string.Format("SELECT pump_status FROM mst_loading_station WHERE coolant_type ='{0}' AND updatedate >= CURRENT_TIMESTAMP - INTERVAL 5 SECOND", coolanttype);

            using (MySqlConnection conn = new MySqlConnection())
            {
                Database.OpenConnection(conn);
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            result = (int)reader["pump_status"];
                        }
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// Function For Loading Check Maintenance Daily
        /// </summary>
        public static bool DailyLoadingStationCheck()
        {
            bool result = false;

            string Now = DateTime.Now.ToString("yyyy-MM-dd");
            char LoadingType = Function.GlobalProperties.CoolantType;

            string query = string.Format("SELECT * FROM trx_loadingstation_status WHERE description='LS {0}' AND createddate LIKE '{1}%'", LoadingType, Now);

            using (MySqlConnection conn = new MySqlConnection())
            {
                Database.OpenConnection(conn);
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            result = true;
                        }
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// Function For [Clicked Ready] Insert Loading Check Maintenance Daily
        /// </summary>
        public static void DailyLoadingStationReady()
        {
            string Now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string query = string.Format("UPDATE trx_loadingstation_status SET createddate='{0}' where description='MT LS {1}'", Now, Function.GlobalProperties.CoolantType);

            using (MySqlConnection conn = new MySqlConnection())
            {
                Database.OpenConnection(conn);
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Function For Update Device Status trx_device_Status
        /// </summary>
        public static void UpdateDeviceStatus(string Ipaddress, int Status)
        {
            string Logdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Database.InsertToMySql($"UPDATE trx_device_status SET logdate='{Logdate}', data_value={Status} WHERE ip_address='{Ipaddress}';");
        }


        /// <summary>
        /// Function For Change Current Status State to Database
        /// </summary>
        public static void CurrentStatusState()
        {
            string Now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string query = string.Format("UPDATE trx_loadingstation_status SET createddate='{0}', status='{1}' WHERE description='LS {2}'", Now, (int)GlobalProperties.CurrentStatus, GlobalProperties.CoolantType);
            System.Diagnostics.Debug.WriteLine($"CURRENT STATUS: {(int)GlobalProperties.CurrentStatus}");
            using (MySqlConnection conn = new MySqlConnection())
            {
                Database.OpenConnection(conn);
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static void GetLoadingMaxMin(string description, out int ValueMax, out int ValueMin)
        {
            ValueMax = ValueMin = 0;
            string query = string.Format("SELECT val_max,val_min FROM mst_loading_calibration WHERE description = '{0}' AND coolant_type='{1}'", description, GlobalProperties.CoolantType);

            using (MySqlConnection conn = new MySqlConnection())
            {
                Database.OpenConnection(conn);
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            ValueMax = (int)reader["val_max"];
                            ValueMin = (int)reader["val_min"];
                        }
                    }
                }
            }
        }

    }
}
