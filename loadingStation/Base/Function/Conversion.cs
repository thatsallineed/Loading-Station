using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

using loadingStation.Base.Connection.Database;

namespace loadingStation.Base.Function
{
    class Conversion
    {
        public static double DrumPercentage(double value, double min = 0, double max = 395)
        {
            double val = value;
            double deviation = max - min;
            double actual = val - min;
            double result = ((actual / deviation) * 100);

            return Math.Round(result, 2);
        }

        public static bool CheckDevice(int SerialNumber)
        {
            /*
             *  Function Serial Number Validator
             *  Flow : SerialNumber --> Binary --> Byte --> SHA256 --> Validation DB
             */

            bool Result = false;
            string ResultBinary = "";
            byte[] ResultBytes = null;
            string ResultByteString = "";
            string ResultEncrypt256 = "";

            try
            {
                // SerialNumber (Decimal) --> Binary
                while (SerialNumber > 1)
                {
                    int remainder = SerialNumber % 2;
                    ResultBinary = Convert.ToString(remainder) + ResultBinary;
                    SerialNumber /= 2;
                }
                ResultBinary = Convert.ToString(SerialNumber) + ResultBinary;

                // Binary --> Byte
                int numOfBytes = ResultBinary.Length / 8;
                ResultBytes = new byte[numOfBytes];
                for (int i = 0; i < numOfBytes; ++i)
                {
                    ResultBytes[i] = Convert.ToByte(ResultBinary.Substring(8 * i, 8), 2);
                }

                // Byte --> String
                int ResultBytesLength = ResultBytes.Length;
                for (int i = 0; i < ResultBytesLength; i++)
                {
                    ResultByteString += ResultBytes[i].ToString();
                }

                // String --> SHA256 --> String
                using (SHA256 encrypt = SHA256.Create())
                {
                    byte[] bytes = encrypt.ComputeHash(Encoding.UTF8.GetBytes(ResultByteString));
                    StringBuilder strBuilder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        strBuilder.Append(bytes[i].ToString("x2"));
                    }
                    ResultEncrypt256 = strBuilder.ToString();
                }

                // Check SHA256.String --> Database.mst_serialnumber
                var CheckSerialFromDB = DB_SFDB.CheckSerialNumber(ResultEncrypt256);
                if (CheckSerialFromDB)
                {
                    Result = true;
                }

                Debug.WriteLine(string.Format("SerialNumber: {0} Binary: {1} , Byte: {2}, SHA256: {3}", SerialNumber.ToString(), ResultBinary.ToString(), ResultByteString, ResultEncrypt256));

            }
            catch { }
            return Result;
        }

        public static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
            TimeSpan diff = date.ToLocalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        public static double ConvertForMeasure(int value)
        {
            double val = double.Parse(value.ToString());
            return val / 100;
        }

        public static double Maps(double Min, double Max, double Value)
        {
            double Deviation = Max - Min;
            double Result = (100 / Deviation) * (Value - Max) + 100;

            return Result;
        }
    }
}
