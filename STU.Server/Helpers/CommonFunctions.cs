using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace STU.Server.Helpers
{
    public static class CommonFunctions
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public static T Clone<T>(this T obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject<T>(json);
        }
        public static bool IsValidEmail(this string emailaddress)
        {
            return Regex.Match(emailaddress, @"(03[23456789]|05[689]|07[06789]|08[123456789]|09[0123456789])+([0-9]{7})\b").Success;
        }

        /// <summary>
        /// format string date yyyyMMdd
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsFormatDate(this string date)
        {
            DateTime dt;
            string formats = "yyyyMMdd";
            if (DateTime.TryParseExact(date, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Vietnamese Mobile Phone Number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsPhoneNumber(this string number)
        {
            return Regex.Match(number, @"(03[23456789]|05[689]|07[06789]|08[123456789]|09[0123456789])+([0-9]{7})\b").Success;
        }

        /// <summary>
        /// string is number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsNumber(this string number)
        {
            return int.TryParse(number, out int n);
        }

        /// <summary>
        /// check 2 table in DataSet
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        public static bool IsTableDataPopulated(this DataSet dataSet)
        {
            return dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[1].Rows.Count > 0;
        }

        public static bool IsNullOrEmpty(this string str)
        {
            if (string.IsNullOrEmpty(str) || str == "") return true;

            return false;
        }

        public static Dictionary<string, object> ConvertToDictionary(this object obj)
        {
            return obj.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .ToDictionary(prop => prop.Name, prop => prop.GetValue(obj) == null ? "" : prop.GetValue(obj));
        }

        public static string HashMD5(this string token)
        {
            var hasdmd5 = MD5.Create();
            var newArray = hasdmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(token));

            // step 2, convert byte array to hex string
            var sb = new StringBuilder();
            for (int i = 0; i < newArray.Length; i++)
            {
                sb.Append(newArray[i].ToString("x2"));
            }

            return sb.ToString();
        }

        public static string ToNoSign(this string value)
        {
            string sRtr = Convert2UnicodeComposed(value);
            #region có dấu -> không dấu thường
            sRtr = sRtr.Replace("ắ", "a");
            sRtr = sRtr.Replace("ẳ", "a");
            sRtr = sRtr.Replace("ẵ", "a");
            sRtr = sRtr.Replace("ằ", "a");
            sRtr = sRtr.Replace("ặ", "a");
            sRtr = sRtr.Replace("ă", "a");

            sRtr = sRtr.Replace("ấ", "a");
            sRtr = sRtr.Replace("ẩ", "a");
            sRtr = sRtr.Replace("ẫ", "a");
            sRtr = sRtr.Replace("ầ", "a");
            sRtr = sRtr.Replace("ậ", "a");
            sRtr = sRtr.Replace("â", "a");

            sRtr = sRtr.Replace("á", "a");
            sRtr = sRtr.Replace("ả", "a");
            sRtr = sRtr.Replace("ã", "a");
            sRtr = sRtr.Replace("à", "a");
            sRtr = sRtr.Replace("ạ", "a");

            sRtr = sRtr.Replace("đ", "d");

            sRtr = sRtr.Replace("ế", "e");
            sRtr = sRtr.Replace("ể", "e");
            sRtr = sRtr.Replace("ễ", "e");
            sRtr = sRtr.Replace("ề", "e");
            sRtr = sRtr.Replace("ệ", "e");
            sRtr = sRtr.Replace("ê", "e");

            sRtr = sRtr.Replace("é", "e");
            sRtr = sRtr.Replace("ẻ", "e");
            sRtr = sRtr.Replace("ẽ", "e");
            sRtr = sRtr.Replace("è", "e");
            sRtr = sRtr.Replace("ẹ", "e");

            sRtr = sRtr.Replace("í", "i");
            sRtr = sRtr.Replace("ỉ", "i");
            sRtr = sRtr.Replace("ĩ", "i");
            sRtr = sRtr.Replace("ì", "i");
            sRtr = sRtr.Replace("ị", "i");

            sRtr = sRtr.Replace("ố", "o");
            sRtr = sRtr.Replace("ổ", "o");
            sRtr = sRtr.Replace("ỗ", "o");
            sRtr = sRtr.Replace("ồ", "o");
            sRtr = sRtr.Replace("ộ", "o");
            sRtr = sRtr.Replace("ô", "o");

            sRtr = sRtr.Replace("ớ", "o");
            sRtr = sRtr.Replace("ở", "o");
            sRtr = sRtr.Replace("ỡ", "o");
            sRtr = sRtr.Replace("ờ", "o");
            sRtr = sRtr.Replace("ợ", "o");
            sRtr = sRtr.Replace("ơ", "o");

            sRtr = sRtr.Replace("ó", "o");
            sRtr = sRtr.Replace("ỏ", "o");
            sRtr = sRtr.Replace("õ", "o");
            sRtr = sRtr.Replace("ò", "o");
            sRtr = sRtr.Replace("ọ", "o");

            sRtr = sRtr.Replace("ứ", "u");
            sRtr = sRtr.Replace("ử", "u");
            sRtr = sRtr.Replace("ữ", "u");
            sRtr = sRtr.Replace("ừ", "u");
            sRtr = sRtr.Replace("ự", "u");
            sRtr = sRtr.Replace("ư", "u");

            sRtr = sRtr.Replace("ú", "u");
            sRtr = sRtr.Replace("ủ", "u");
            sRtr = sRtr.Replace("ũ", "u");
            sRtr = sRtr.Replace("ù", "u");
            sRtr = sRtr.Replace("ụ", "u");

            sRtr = sRtr.Replace("ý", "y");
            sRtr = sRtr.Replace("ỷ", "y");
            sRtr = sRtr.Replace("ỹ", "y");
            sRtr = sRtr.Replace("ỳ", "y");
            sRtr = sRtr.Replace("ỵ", "y");
            #endregion
            #region có dấu -> không dấu hoa
            #region viết hoa
            sRtr = sRtr.Replace("Ắ", "A");
            sRtr = sRtr.Replace("Ẳ", "A");
            sRtr = sRtr.Replace("Ẵ", "A");
            sRtr = sRtr.Replace("Ằ", "A");
            sRtr = sRtr.Replace("Ặ", "A");
            sRtr = sRtr.Replace("Ă", "A");

            sRtr = sRtr.Replace("Ấ", "A");
            sRtr = sRtr.Replace("Ẩ", "A");
            sRtr = sRtr.Replace("Ẫ", "A");
            sRtr = sRtr.Replace("Ầ", "A");
            sRtr = sRtr.Replace("Ậ", "A");
            sRtr = sRtr.Replace("Â", "A");

            sRtr = sRtr.Replace("Á", "A");
            sRtr = sRtr.Replace("Ả", "A");
            sRtr = sRtr.Replace("Ã", "A");
            sRtr = sRtr.Replace("À", "A");
            sRtr = sRtr.Replace("Ạ", "A");

            sRtr = sRtr.Replace("Đ", "D");

            sRtr = sRtr.Replace("Ế", "E");
            sRtr = sRtr.Replace("Ể", "E");
            sRtr = sRtr.Replace("Ễ", "E");
            sRtr = sRtr.Replace("Ề", "E");
            sRtr = sRtr.Replace("Ệ", "E");
            sRtr = sRtr.Replace("Ê", "E");

            sRtr = sRtr.Replace("É", "E");
            sRtr = sRtr.Replace("Ẻ", "E");
            sRtr = sRtr.Replace("Ẽ", "E");
            sRtr = sRtr.Replace("È", "E");
            sRtr = sRtr.Replace("Ẹ", "E");

            sRtr = sRtr.Replace("Í", "I");
            sRtr = sRtr.Replace("Ỉ", "I");
            sRtr = sRtr.Replace("Ĩ", "I");
            sRtr = sRtr.Replace("Ì", "I");
            sRtr = sRtr.Replace("Ị", "I");

            sRtr = sRtr.Replace("Ố", "O");
            sRtr = sRtr.Replace("Ổ", "O");
            sRtr = sRtr.Replace("Ỗ", "O");
            sRtr = sRtr.Replace("Ồ", "O");
            sRtr = sRtr.Replace("Ộ", "O");
            sRtr = sRtr.Replace("Ô", "O");

            sRtr = sRtr.Replace("Ớ", "O");
            sRtr = sRtr.Replace("Ở", "O");
            sRtr = sRtr.Replace("Ỡ", "O");
            sRtr = sRtr.Replace("Ờ", "O");
            sRtr = sRtr.Replace("Ợ", "O");
            sRtr = sRtr.Replace("Ơ", "O");

            sRtr = sRtr.Replace("Ó", "O");
            sRtr = sRtr.Replace("Ỏ", "O");
            sRtr = sRtr.Replace("Õ", "O");
            sRtr = sRtr.Replace("Ò", "O");
            sRtr = sRtr.Replace("Ọ", "O");

            sRtr = sRtr.Replace("Ứ", "U");
            sRtr = sRtr.Replace("Ử", "U");
            sRtr = sRtr.Replace("Ữ", "U");
            sRtr = sRtr.Replace("Ừ", "U");
            sRtr = sRtr.Replace("Ự", "U");
            sRtr = sRtr.Replace("Ư", "U");

            sRtr = sRtr.Replace("Ú", "U");
            sRtr = sRtr.Replace("Ủ", "U");
            sRtr = sRtr.Replace("Ũ", "U");
            sRtr = sRtr.Replace("Ù", "U");
            sRtr = sRtr.Replace("Ụ", "U");

            sRtr = sRtr.Replace("Ý", "Y");
            sRtr = sRtr.Replace("Ỷ", "Y");
            sRtr = sRtr.Replace("Ỹ", "Y");
            sRtr = sRtr.Replace("Ỳ", "Y");
            sRtr = sRtr.Replace("Ỵ", "Y");
            #endregion
            #endregion
            return sRtr;
        }

        public static string Convert2UnicodeComposed(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return "";
            string sRtr = source.Trim();

            #region Unicode dựng sẵn -> Unicode tổ hợp
            #region viết thường
            sRtr = sRtr.Replace("ắ", "ắ");
            sRtr = sRtr.Replace("ẳ", "ẳ");
            sRtr = sRtr.Replace("ẵ", "ẵ");
            sRtr = sRtr.Replace("ằ", "ằ");
            sRtr = sRtr.Replace("ặ", "ặ");
            sRtr = sRtr.Replace("ă", "ă");

            sRtr = sRtr.Replace("ấ", "ấ");
            sRtr = sRtr.Replace("ẩ", "ẩ");
            sRtr = sRtr.Replace("ẫ", "ẫ");
            sRtr = sRtr.Replace("ầ", "ầ");
            sRtr = sRtr.Replace("ậ", "ậ");
            sRtr = sRtr.Replace("â", "â");

            sRtr = sRtr.Replace("á", "á");
            sRtr = sRtr.Replace("ả", "ả");
            sRtr = sRtr.Replace("ã", "ã");
            sRtr = sRtr.Replace("à", "à");
            sRtr = sRtr.Replace("ạ", "ạ");

            sRtr = sRtr.Replace("đ", "đ");

            sRtr = sRtr.Replace("ế", "ế");
            sRtr = sRtr.Replace("ể", "ể");
            sRtr = sRtr.Replace("ễ", "ễ");
            sRtr = sRtr.Replace("ề", "ề");
            sRtr = sRtr.Replace("ệ", "ệ");
            sRtr = sRtr.Replace("ê", "ê");

            sRtr = sRtr.Replace("é", "é");
            sRtr = sRtr.Replace("ẻ", "ẻ");
            sRtr = sRtr.Replace("ẽ", "ẽ");
            sRtr = sRtr.Replace("è", "è");
            sRtr = sRtr.Replace("ẹ", "ẹ");

            sRtr = sRtr.Replace("í", "í");
            sRtr = sRtr.Replace("ỉ", "ỉ");
            sRtr = sRtr.Replace("ĩ", "ĩ");
            sRtr = sRtr.Replace("ì", "ì");
            sRtr = sRtr.Replace("ị", "ị");

            sRtr = sRtr.Replace("ố", "ố");
            sRtr = sRtr.Replace("ổ", "ổ");
            sRtr = sRtr.Replace("ỗ", "ỗ");
            sRtr = sRtr.Replace("ồ", "ồ");
            sRtr = sRtr.Replace("ộ", "ộ");
            sRtr = sRtr.Replace("ô", "ô");

            sRtr = sRtr.Replace("ớ", "ớ");
            sRtr = sRtr.Replace("ở", "ở");
            sRtr = sRtr.Replace("ỡ", "ỡ");
            sRtr = sRtr.Replace("ờ", "ờ");
            sRtr = sRtr.Replace("ợ", "ợ");
            sRtr = sRtr.Replace("ơ", "ơ");

            sRtr = sRtr.Replace("ó", "ó");
            sRtr = sRtr.Replace("ỏ", "ỏ");
            sRtr = sRtr.Replace("õ", "õ");
            sRtr = sRtr.Replace("ò", "ò");
            sRtr = sRtr.Replace("ọ", "ọ");

            sRtr = sRtr.Replace("ứ", "ứ");
            sRtr = sRtr.Replace("ử", "ử");
            sRtr = sRtr.Replace("ữ", "ữ");
            sRtr = sRtr.Replace("ừ", "ừ");
            sRtr = sRtr.Replace("ự", "ự");
            sRtr = sRtr.Replace("ư", "ư");

            sRtr = sRtr.Replace("ú", "ú");
            sRtr = sRtr.Replace("ủ", "ủ");
            sRtr = sRtr.Replace("ũ", "ũ");
            sRtr = sRtr.Replace("ù", "ù");
            sRtr = sRtr.Replace("ụ", "ụ");

            sRtr = sRtr.Replace("ý", "ý");
            sRtr = sRtr.Replace("ỷ", "ỷ");
            sRtr = sRtr.Replace("ỹ", "ỹ");
            sRtr = sRtr.Replace("ỳ", "ỳ");
            sRtr = sRtr.Replace("ỵ", "ỵ");
            #endregion

            #region viết hoa
            sRtr = sRtr.Replace("Ắ", "Ắ");
            sRtr = sRtr.Replace("Ẳ", "Ẳ");
            sRtr = sRtr.Replace("Ẵ", "Ẵ");
            sRtr = sRtr.Replace("Ằ", "Ằ");
            sRtr = sRtr.Replace("Ặ", "Ặ");
            sRtr = sRtr.Replace("Ă", "Ă");

            sRtr = sRtr.Replace("Ấ", "Ấ");
            sRtr = sRtr.Replace("Ẩ", "Ẩ");
            sRtr = sRtr.Replace("Ẫ", "Ẫ");
            sRtr = sRtr.Replace("Ầ", "Ầ");
            sRtr = sRtr.Replace("Ậ", "Ậ");
            sRtr = sRtr.Replace("Â", "Â");

            sRtr = sRtr.Replace("Á", "Á");
            sRtr = sRtr.Replace("Ả", "Ả");
            sRtr = sRtr.Replace("Ã", "Ã");
            sRtr = sRtr.Replace("À", "À");
            sRtr = sRtr.Replace("Ạ", "Ạ");

            sRtr = sRtr.Replace("Đ", "Đ");

            sRtr = sRtr.Replace("Ế", "Ế");
            sRtr = sRtr.Replace("Ể", "Ể");
            sRtr = sRtr.Replace("Ễ", "Ễ");
            sRtr = sRtr.Replace("Ề", "Ề");
            sRtr = sRtr.Replace("Ệ", "Ệ");
            sRtr = sRtr.Replace("Ê", "Ê");

            sRtr = sRtr.Replace("É", "É");
            sRtr = sRtr.Replace("Ẻ", "Ẻ");
            sRtr = sRtr.Replace("Ẽ", "Ẽ");
            sRtr = sRtr.Replace("È", "È");
            sRtr = sRtr.Replace("Ẹ", "Ẹ");

            sRtr = sRtr.Replace("Í", "Í");
            sRtr = sRtr.Replace("Ỉ", "Ỉ");
            sRtr = sRtr.Replace("Ĩ", "Ĩ");
            sRtr = sRtr.Replace("Ì", "Ì");
            sRtr = sRtr.Replace("Ị", "Ị");

            sRtr = sRtr.Replace("Ố", "Ố");
            sRtr = sRtr.Replace("Ổ", "Ổ");
            sRtr = sRtr.Replace("Ỗ", "Ỗ");
            sRtr = sRtr.Replace("Ồ", "Ồ");
            sRtr = sRtr.Replace("Ộ", "Ộ");
            sRtr = sRtr.Replace("Ô", "Ô");

            sRtr = sRtr.Replace("Ớ", "Ớ");
            sRtr = sRtr.Replace("Ở", "Ở");
            sRtr = sRtr.Replace("Ỡ", "Ỡ");
            sRtr = sRtr.Replace("Ờ", "Ờ");
            sRtr = sRtr.Replace("Ợ", "Ợ");
            sRtr = sRtr.Replace("Ơ", "Ơ");

            sRtr = sRtr.Replace("Ó", "Ó");
            sRtr = sRtr.Replace("Ỏ", "Ỏ");
            sRtr = sRtr.Replace("Õ", "Õ");
            sRtr = sRtr.Replace("Ò", "Ò");
            sRtr = sRtr.Replace("Ọ", "Ọ");

            sRtr = sRtr.Replace("Ứ", "Ứ");
            sRtr = sRtr.Replace("Ử", "Ử");
            sRtr = sRtr.Replace("Ữ", "Ữ");
            sRtr = sRtr.Replace("Ừ", "Ừ");
            sRtr = sRtr.Replace("Ự", "Ự");
            sRtr = sRtr.Replace("Ư", "Ư");

            sRtr = sRtr.Replace("Ú", "Ú");
            sRtr = sRtr.Replace("Ủ", "Ủ");
            sRtr = sRtr.Replace("Ũ", "Ũ");
            sRtr = sRtr.Replace("Ù", "Ù");
            sRtr = sRtr.Replace("Ụ", "Ụ");

            sRtr = sRtr.Replace("Ý", "Ý");
            sRtr = sRtr.Replace("Ỷ", "Ỷ");
            sRtr = sRtr.Replace("Ỹ", "Ỹ");
            sRtr = sRtr.Replace("Ỳ", "Ỳ");
            sRtr = sRtr.Replace("Ỵ", "Ỵ");
            #endregion
            #endregion

            return sRtr;
        }

        public static TResponse ReadJsonFile<TResponse>(this string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<TResponse>(json);
            }
        }

        public static void WriteJsonFile(this object model, string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(model));
        }

        public static string ReadFile(this string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                var str = r.ReadToEnd();
                return str;
            }
        }

        public static string GenerateRandomString(int length = 6, bool onlyDigits = true)
        {
            var random = new Random();
            if (!onlyDigits)
            {
                return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            }
            else
            {
                string s = string.Empty;
                for (int i = 0; i < length; i++)
                {
                    s = String.Concat(s, random.Next(10).ToString());
                }
                return s;
            }
        }

        public static double ConvertToDouble(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0;
            return Double.Parse(value);
        }

        public static int ConvertToInt(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0;
            return Int32.Parse(value);
        }

        public static T ConvertToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        public static DateTime ConvertToDatetime(this string str)
        {
            if (string.IsNullOrEmpty(str)) return DateTime.MinValue;

            return DateTime.ParseExact(str, "ddMMyyyy", null);
        }
    }
}
