namespace Seq.App.aspsms.Models
{
    /// <summary>
    /// Needed JSON object to send a SMS
    /// </summary>
    public class CheckCredits
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }

        /// <summary>
        /// Create a new instance of CheckCredits
        /// </summary>
        public CheckCredits(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
