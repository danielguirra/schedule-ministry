using System.Text.RegularExpressions;

namespace ApiEscala.Utils
{
    public static class IsBase64
    {
        public static bool IsBase64String(string base64)
        {
            if (string.IsNullOrWhiteSpace(base64))
                return false;

            var commaIndex = base64.IndexOf(',');
            if (commaIndex >= 0)
                base64 = base64[(commaIndex + 1)..];

            var base64Regex = new Regex(@"^[a-zA-Z0-9\+/]*={0,2}$", RegexOptions.None);

            return base64.Length % 4 == 0 && base64Regex.IsMatch(base64);
        }
    }
}
