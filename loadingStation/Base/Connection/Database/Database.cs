﻿using loadingStation.Base.Function;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;

namespace loadingStation.Base.Connection.Database
{
    class Database
    {
        public static string MyConnectionString = string.Format("server={0};database={1};user={2};password={3};",
                                                  GlobalProperties.Configuration.DatabaseHost,
                                                  GlobalProperties.Configuration.DatabaseDB,
                                                  GlobalProperties.Configuration.DatabaseUsername,
                                                  GlobalProperties.Configuration.DatabasePassword);
        public static bool IsConnected()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(MyConnectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void OpenConnection(MySqlConnection conn)
        {
            try
            {
                conn.ConnectionString = MyConnectionString;
                conn.Open();
            }
            catch (Exception e)
            {
                Log.Error.Collect(e.StackTrace.ToString());
            }
        }

        public static void CloseConnection(MySqlConnection conn)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception e)
            {
                Log.Error.Collect(e.StackTrace.ToString());
            }
        }

        public static int InsertToMySql(string stQuery)
        {
            int RowsAffected = 0;

            using (MySqlConnection conn = new MySqlConnection(MyConnectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(stQuery, conn))
                {
                    RowsAffected = cmd.ExecuteNonQuery();
                }
            }

            /*
            try
            {
                
            }
            catch (Exception e)
            {
                Log.Error.Collect(e.StackTrace.ToString());
            }
            */
            return RowsAffected;
        }

        public static int DeleteFromMySql(string stQuery)
        {
            int RowsAffected = 0;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(MyConnectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(stQuery, conn))
                    {
                        RowsAffected = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error.Collect(e.StackTrace.ToString());
            }
            return RowsAffected;
        }

        // Baca data dari MySql Simpan ke DataTable
        public static DataTable MySqlToDataTable(string stQuery)
        {
            MySqlConnection conn = new MySqlConnection(MyConnectionString);

            try
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(stQuery, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error.Collect(e.StackTrace.ToString());
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return null;
            }
        }

        public static string BulkInsert(ref DataTable table, string table_name)
        {
            try
            {
                StringBuilder queryBuilder = new StringBuilder();
                DateTime dt;

                queryBuilder.AppendFormat("INSERT INTO `{0}` (", table_name);

                // more than 1 column required and 1 or more rows
                if (table.Columns.Count > 1 && table.Rows.Count > 0)
                {
                    // build all columns
                    queryBuilder.AppendFormat("`{0}`", table.Columns[0].ColumnName);

                    if (table.Columns.Count > 1)
                    {
                        for (int i = 1; i < table.Columns.Count; i++)
                        {
                            queryBuilder.AppendFormat(", `{0}` ", table.Columns[i].ColumnName);
                        }
                    }

                    queryBuilder.AppendFormat(") VALUES (", table_name);

                    // build all values for the first row
                    // escape String & Datetime values!
                    if (table.Columns[0].DataType == typeof(String))
                    {
                        queryBuilder.AppendFormat("'{0}'", MySqlHelper.EscapeString(table.Rows[0][table.Columns[0].ColumnName].ToString()));
                    }
                    else if (table.Columns[0].DataType == typeof(DateTime))
                    {
                        dt = (DateTime)table.Rows[0][table.Columns[0].ColumnName];
                        queryBuilder.AppendFormat("'{0}'", dt.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    else if (table.Columns[0].DataType == typeof(Int32))
                    {
                        queryBuilder.AppendFormat("{0}", table.Rows[0].Field<Int32?>(table.Columns[0].ColumnName) ?? 0);
                    }
                    else
                    {
                        queryBuilder.AppendFormat(", {0}", table.Rows[0][table.Columns[0].ColumnName].ToString());
                    }

                    for (int i = 1; i < table.Columns.Count; i++)
                    {
                        // escape String & Datetime values!
                        if (table.Columns[i].DataType == typeof(String))
                        {
                            queryBuilder.AppendFormat(", '{0}'", MySqlHelper.EscapeString(table.Rows[0][table.Columns[i].ColumnName].ToString()));
                        }
                        else if (table.Columns[i].DataType == typeof(DateTime))
                        {
                            dt = (DateTime)table.Rows[0][table.Columns[i].ColumnName];
                            queryBuilder.AppendFormat(", '{0}'", dt.ToString("yyyy-MM-dd HH:mm:ss"));

                        }
                        else if (table.Columns[i].DataType == typeof(Int32))
                        {
                            queryBuilder.AppendFormat(", {0}", table.Rows[0].Field<Int32?>(table.Columns[i].ColumnName) ?? 0);
                        }
                        else
                        {
                            queryBuilder.AppendFormat(", {0}", table.Rows[0][table.Columns[i].ColumnName].ToString());
                        }
                    }

                    queryBuilder.Append(")");
                    queryBuilder.AppendLine();

                    // build all values all remaining rows
                    if (table.Rows.Count > 1)
                    {
                        // iterate over the rows
                        for (int row = 1; row < table.Rows.Count; row++)
                        {
                            // open value block
                            queryBuilder.Append(", (");

                            // escape String & Datetime values!
                            if (table.Columns[0].DataType == typeof(String))
                            {
                                queryBuilder.AppendFormat("'{0}'", MySqlHelper.EscapeString(table.Rows[row][table.Columns[0].ColumnName].ToString()));
                            }
                            else if (table.Columns[0].DataType == typeof(DateTime))
                            {
                                dt = (DateTime)table.Rows[row][table.Columns[0].ColumnName];
                                queryBuilder.AppendFormat("'{0}'", dt.ToString("yyyy-MM-dd HH:mm:ss"));
                            }
                            else if (table.Columns[0].DataType == typeof(Int32))
                            {
                                queryBuilder.AppendFormat("{0}", table.Rows[row].Field<Int32?>(table.Columns[0].ColumnName) ?? 0);
                            }
                            else
                            {
                                queryBuilder.AppendFormat(", {0}", table.Rows[row][table.Columns[0].ColumnName].ToString());
                            }

                            for (int col = 1; col < table.Columns.Count; col++)
                            {
                                // escape String & Datetime values!
                                if (table.Columns[col].DataType == typeof(String))
                                {
                                    queryBuilder.AppendFormat(", '{0}'", MySqlHelper.EscapeString(table.Rows[row][table.Columns[col].ColumnName].ToString()));
                                }
                                else if (table.Columns[col].DataType == typeof(DateTime))
                                {
                                    dt = (DateTime)table.Rows[row][table.Columns[col].ColumnName];
                                    queryBuilder.AppendFormat(", '{0}'", dt.ToString("yyyy-MM-dd HH:mm:ss"));
                                }
                                else if (table.Columns[col].DataType == typeof(Int32))
                                {
                                    queryBuilder.AppendFormat(", {0}", table.Rows[row].Field<Int32?>(table.Columns[col].ColumnName) ?? 0);
                                }
                                else
                                {
                                    queryBuilder.AppendFormat(", {0}", table.Rows[row][table.Columns[col].ColumnName].ToString());
                                }
                            } // end for (int i = 1; i < table.Columns.Count; i++)

                            // close value block
                            queryBuilder.Append(")");
                            queryBuilder.AppendLine();

                        } // end for (int r = 1; r < table.Rows.Count; r++)

                        // sql delimiter =)
                        queryBuilder.Append(";");

                    } // end if (table.Rows.Count > 1)

                    return queryBuilder.ToString();
                }
                else
                {
                    return "";
                } // end if(table.Columns.Count > 1 && table.Rows.Count > 0)
            }
            catch (Exception e)
            {
                Log.Error.Collect(e.StackTrace.ToString());
                return "";
            }
        }

    }
}
