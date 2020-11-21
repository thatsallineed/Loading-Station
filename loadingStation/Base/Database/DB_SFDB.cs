using System;
using System.Data;
using loadingStation.Core.Function;
using MySql.Data.MySqlClient;

namespace loadingStation.Core.Database
{
    class DB_SFDB
    {
        #region Private Properties
        static DataTable dtUser = new DataTable();
        #endregion

        /// <summary>
        /// Function For Reading MySql sfdb.mst_user to bool
        /// </summary>
        public static bool LoginAuthentication(string nrp)
        {
            bool result = false;
            string query = string.Format("SELECT * FROM sfdb.mst_user WHERE BINARY nrp= '{0}'", nrp);

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
            string query = string.Format("SELECT * FROM sfdb.mst_user WHERE BINARY nrp= '{0}' AND level=4", nrp);

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
        /// Function For Reading Mysql sfdb.trx_tasklist to DataTable
        /// </summary>
        public static DataTable PopulateTasklist()
        {
            string Now = DateTime.Now.ToString("yyyy-MM-dd");
            char coolanttype = Function.GlobalProperties.CoolantType;
            string query = string.Format("SELECT id, nrp, date_time, no_asset, op_name, concentrate, ph, level_coolant, coolant_type, status FROM sfdb.trx_tasklist WHERE date_time LIKE '{0}%' AND coolant_type = '{1}' ORDER BY date_time ASC",Now,coolanttype.ToString());

            return Database.MySqlToDataTable(query);
        }


        /// <summary>
        /// Function For Reading Mysql sfdb.mst_user to DataTable
        /// </summary>
        public static DataTable PopulateUser()
        {
            string query = "SELECT * FROM sfdb.mst_user";
            dtUser = Database.MySqlToDataTable(query);
            return dtUser;
        }


        /// <summary>
        /// Function For Reading Mysql sfdb.trx_history_loading to DataTable
        /// </summary>
        public static DataTable PopulateHistory(char typecoolant)
        {
            string query = string.Format("SELECT id AS ID, coolant_type as Type, userid AS NRP, createddate as Date FROM sfdb.mst_history_loading WHERE coolant_type = '{0}' order by id desc limit 0, 14", typecoolant);
            return Database.MySqlToDataTable(query);
        }


        /// <summary>
        /// Function For Reading Mysql sfdb.machine to DataTable
        /// </summary>
        public static string[] PopulateOverview(string idbarcode)
        {
            string query = string.Format("SELECT * FROM machine WHERE id_barcode=\"{0}\"", idbarcode);
            string[] result = null;

            using(MySqlConnection conn = new MySqlConnection())
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
            string query = string.Format("INSERT INTO `mst_history_loading` (`id`, `userid`, `coolant_type`, `createddate`) VALUES (NULL, '{0}', '{1}', (SELECT NOW()));", UserId, CoolantType);

            using(MySqlConnection conn = new MySqlConnection())
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
            string query = string.Format("SELECT serialnumber FROM sfdb.mst_serialnumber where serialnumber=\"{0}\"", SerialByte);
            bool result = false;

            using(MySqlConnection conn = new MySqlConnection())
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
        /// Function For Insert Mysql sfdb.trx_real_loading
        /// </summary>
        public static void InsertTrxRealLoading(int ID1, int ID2, int ID3, double value1, double value2, double value3)
        {
            var datenow = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");
            var epochtime = Function.Conversion.ConvertToUnixTimestamp(DateTime.Now);

            string query = string.Format
                (
                "INSERT INTO " +
                "`sfdb`.`trx_real_loading` " +
                "(`loadingdetailid`, `createddate`, `epoch_time`, `data_value`) " +
                "VALUES " +
                "('{0}', '{1}', '{2}', '{3}'), " +
                "('{4}', '{5}', '{6}', '{7}'), " +
                "('{8}', '{9}', '{10}', '{11}'); "
                , ID1, datenow, epochtime, value1
                , ID2, datenow, epochtime, value2
                , ID3, datenow, epochtime, value3
                );

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
        /// Function For Reading Mysql sfdb.mst_loading_station
        /// </summary>
        public static string IpDigitalInput()
        {
            string result = "";
            var coolanttype = Function.GlobalProperties.CoolantType;
            string query = string.Format("SELECT ipdigitalinput FROM sfdb.mst_loading_station WHERE coolant_type='{0}';", coolanttype);

            using(MySqlConnection conn = new MySqlConnection())
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
        /// Function For Reading Mysql sfdb.mst_loading_station
        /// </summary>
        public static string IpDigitalOutput()
        {
            string result = "";
            var coolanttype = Function.GlobalProperties.CoolantType;
            string query = string.Format("SELECT ipdigitaloutput FROM mst_loading_station WHERE coolant_type='{0}';", coolanttype);

            using(MySqlConnection conn = new MySqlConnection())
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
        /// Function For Truncate Mysql sfdb.trx_real_loading
        /// </summary>
        public static void TruncateRealLoading()
        {
            string query = "TRUNCATE TABLE trx_real_loading;";

            using(MySqlConnection conn = new MySqlConnection())
            {
                Database.OpenConnection(conn);
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Function For GET Max & Min Value sfdb.mst_detail_loading
        /// </summary>
        /*public static int[] GetDetailLoadingMaxMinValue(int channel)
        {
            int[] result = null;

            string query = string.Format("SELECT min_value,max_value FROM sfdb.mst_detail_loading WHERE channel = {0} AND coolant_type='{1}'", channel,PublicProperties.CoolantType.ToString());

            using(MySqlConnection conn = new MySqlConnection())
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
        }*/

        public static void GetLoadingMaxMin(string description, out int ValueMin, out int ValueMax)
        {
            ValueMax = ValueMin = 0;
            string query = string.Format("SELECT val_max,val_min FROM sfdb.mst_loading_calibration WHERE description = '{0}' AND coolant_type='{1}'", description, GlobalProperties.CoolantType);

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


        /// <summary>
        /// Function For Get Pump Status,Updatedate sfdb.mst_loading_station
        /// </summary>
        public static int GetPumpStatus()
        {
            int result = 0;

            char coolanttype = Function.GlobalProperties.CoolantType;
            string query = string.Format("SELECT pump_status FROM mst_loading_station WHERE coolant_type ='{0}' AND updatedate >= CURRENT_TIMESTAMP - INTERVAL 5 SECOND", coolanttype);

            using(MySqlConnection conn = new MySqlConnection())
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

            char LoadingType = Function.GlobalProperties.CoolantType;
            string now = DateTime.Now.ToString("yyyy-MM-dd");

            string query = string.Format("SELECT * FROM trx_system_status WHERE description='MT LS {0}' AND createddate LIKE '{1}%'", LoadingType,now);

            using(MySqlConnection conn = new MySqlConnection())
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
            string query = string.Format("UPDATE trx_system_status SET createddate=(SELECT NOW()) where description='MT LS {0}'", Function.GlobalProperties.CoolantType);

            using(MySqlConnection conn = new MySqlConnection())
            {
                Database.OpenConnection(conn);
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Function For Change Current Status State to Database
        /// </summary>
        public static void CurrentStatusState()
        {
            string query = string.Format("UPDATE trx_system_status SET createddate=(SELECT NOW()), status='{0}' WHERE description='LS {1}'", Function.GlobalProperties.CurrentStatus.ToString().ToUpper(), Function.GlobalProperties.CoolantType);

            using(MySqlConnection conn = new MySqlConnection())
            {
                Database.OpenConnection(conn);
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Function For Dashboard Coolant Consumption
        /// </summary>
        public static int CoolantConsumption(int timeindex)
        {
            int result = 0;
            string query = string.Format("");
            using(MySqlConnection conn = new MySqlConnection())
            {
                Database.OpenConnection(conn);
                using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            result = (int)reader["sum"];
                        }
                    }
                }
            }
            return result;
            // ON PROGRESS!!
        }


        /// <summary>
        /// Function For Dashboard Water Consumption
        /// </summary>
        public static int WaterConsumption(int timeindex)
        {
            int result = 0;
            string query = string.Format("");
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
                            result = (int)reader["sum"];
                        }
                    }
                }
            }
            return result;
            // ON PROGRESS!!
        }
    }
}
