namespace AndGearbest.Client
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public static class RequestHelper
    {
        public static string CreateMD5Key(string input, bool replaceSlash)
        {
            var result = string.Empty;

            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                result = BitConverter.ToString(hashBytes);
            }

            if (replaceSlash)
                return result.Replace("-", "").ToUpper();

            return result;
        }
    }
}