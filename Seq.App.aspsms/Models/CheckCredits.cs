using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Seq.App.aspsms.Models
{
    /// <summary>
    /// Needed JSON object to send a SMS
    /// </summary>
    [DataContract]
    public class CheckCredits
    {
        [DataMember]
        public string UserName { get; private set; }
        [DataMember]
        public string Password { get; private set; }

        /// <summary>
        /// Create a new instance of CheckCredits
        /// </summary>
        public CheckCredits(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        /// <summary>
        /// Returns the class as JSON object
        /// </summary>
        public string GetAsJson()
        {
            using (var stream = new MemoryStream())
            {
                var ser = new DataContractJsonSerializer(typeof(CheckCredits));
                ser.WriteObject(stream, this);
                return Encoding.Default.GetString(stream.ToArray());
            }
        }
    }
}
