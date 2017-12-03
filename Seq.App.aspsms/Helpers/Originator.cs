using System.Text.RegularExpressions;

namespace Seq.App.aspsms.Helpers
{
    /// <summary>
    /// Just basic checks - not much magic here
    /// </summary>
    public static class Originator
    {
        public static bool IsValidAlphabetic(string value)
        {
            return Regex.Matches(value, "([a-z,A-Z,\" *\"]){1,11}").Count == 1;
        }

        public static bool IsValidPhoneNumber(string value)
        {
            return Regex.Matches(value, "^[+]([0-9]){11,}").Count == 1;
        }
    }
}
