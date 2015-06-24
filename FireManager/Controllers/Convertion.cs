﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using FireManager.Models;

namespace FireManager.Controllers
{
    static class Conversions
    {
        private const double THREE_AND_ONE_THIRD = 10 / 3.0d;

        public static int ConvertToInt(string hex)
        {
            var converted = int.Parse(BitUtil.Reverse(hex), NumberStyles.HexNumber);
            return converted;
        }

        public static string ConvertToDateTime(string hex)
        {
            var dateBytes = BitUtil.FromHex(hex);
            
            return new DateTime(1900, 1, 1).AddDays(BitUtil.ToInt32(dateBytes, 4, true)).
                           AddMilliseconds(THREE_AND_ONE_THIRD * BitUtil.ToInt32(dateBytes, 0, true)).
                           ToString(CultureInfo.InvariantCulture);
        }

        public static char ConvertToChar(string hex)
        {
            var num = int.Parse(BitUtil.Reverse(hex), NumberStyles.AllowHexSpecifier);
            var cnum = (char)num;

            return cnum;
        }

        public static string ConvertToTinyInt(string hex)
        {
            if (hex == null) throw new ArgumentNullException("hex");
            var data = BitUtil.FromHex(BitUtil.Reverse(hex));
            return ((int)data[0]).ToString();
        }

        public static double ConvertToFloat(string hex)
        {
            var dateBytes = BitUtil.FromHex(hex);

            return BitUtil.ToDouble(dateBytes, 0, true);
        }

        public static BigInteger ConvertToBigInt(string hex)
        {
            return BigInteger.Parse(BitUtil.Reverse(hex), NumberStyles.HexNumber);
        }
        
        public static string ConvertToVarchar(string hex)
        {
            var sData = "";
            while (hex.Length > 0)
            {
                var data1 = Convert.ToChar(Convert.ToUInt32(hex.Substring(0, 2), 16)).ToString();
                sData = sData + data1;
                hex = hex.Substring(2, hex.Length - 2);
            }
            return sData;
        }

       

        public static float ConvertToReal(string hex)
        {
           var bytes = BitUtil.FromHex(hex);
           return BitUtil.ToSingle(bytes, 0, true);
        }

        public static double ConvertToMoney(string hex)
        {
            var dateBytes = BitUtil.FromHex(hex);

            return BitUtil.ToInt64(dateBytes, 0, true) / 10000d;
        }

        public static bool ConvertToBit(string hex)
        {
            var bytes = BitUtil.FromHex(hex);
            
            return (bytes[0] & 1) != 0;
        }

        public static decimal ConvertToDecimal(string hex)
        {
            var hexNumber = BitUtil.Reverse(hex).Substring(0, 14);
            hexNumber = hexNumber.Replace("x", string.Empty);
            long result;
            long.TryParse(hexNumber, NumberStyles.HexNumber, null, out result);

            return result;
        }

        public static DateTime ConvertToSmallDateTime(string hex)
        {
            var data = BitUtil.FromHex((hex));
            var returnDate = new DateTime(1900, 1, 1);

            int timePart = BitConverter.ToUInt16(data, 0);
            int datePart = BitConverter.ToUInt16(data, 2);

            returnDate = returnDate.AddDays(datePart).AddMinutes(timePart);

            return returnDate;
        }

        public static StringBuilder ConvertToBinary(string hex)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in hex)
            {
                // This will crash for non-hex characters. You might want to handle that differently.
                result.Append(HexCharacterToBinary[char.ToLower(c)]);
            }
            return result;
        }

        private static readonly Dictionary<char, string> HexCharacterToBinary = new Dictionary<char, string> {
            { '0', "0000" },
            { '1', "0001" },
            { '2', "0010" },
            { '3', "0011" },
            { '4', "0100" },
            { '5', "0101" },
            { '6', "0110" },
            { '7', "0111" },
            { '8', "1000" },
            { '9', "1001" },
            { 'a', "1010" },
            { 'b', "1011" },
            { 'c', "1100" },
            { 'd', "1101" },
            { 'e', "1110" },
            { 'f', "1111" }
        };

        public static string ConvertToNumeric(string substring)
        {
            throw new NotImplementedException();
        }
    }
}
