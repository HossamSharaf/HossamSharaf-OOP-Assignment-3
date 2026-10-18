using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp8
{
    public static class StringValidationExtensions
    {
        public static bool IsValidEgyptianPhone(this string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            string pattern = @"^(0|\+20)1[0125]\d{8}$";

            return Regex.IsMatch(phone, pattern);
        }

        public static bool IsValidEgyptianNationalId(this string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return false;

           
            string pattern = @"^[23]\d{13}$";

            return Regex.IsMatch(id, pattern);
        }
    }
}