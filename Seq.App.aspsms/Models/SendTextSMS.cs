using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Seq.App.aspsms.Models
{
    /// <summary>
    /// Needed JSON object to Send a text SMS
    /// </summary>
    [DataContract]
    public class SendTextSMS
    {
        [DataMember]
        public string UserName { get; private set; }
        [DataMember]
        public string Password { get; private set; }
        [DataMember]
        public string Originator { get; private set; }
        [DataMember]
        public string[] Recipients { get; private set; }
        [DataMember]
        public string MessageText { get; private set; }
        [DataMember]
        public string DeferredDeliveryTime { get; private set; }
        [DataMember]
        public string FlashingSMS { get; private set; }
        [DataMember(EmitDefaultValue = false)]
        public string URLBufferedMessageNotification { get; private set; }
        [DataMember(EmitDefaultValue = false)]
        public string URLDeliveryNotification { get; private set; }
        [DataMember(EmitDefaultValue = false)]
        public string URLNonDeliveryNotification { get; private set; }
        [DataMember(EmitDefaultValue = false)]
        public string AffiliateID { get; private set; }

        /// <summary>
        /// Create a new instance
        /// </summary>
        public SendTextSMS(string userName, string password, string originator, string recipients, string messageText, bool flashingSMS, string urlBufferedMessageNotification, string urlDeliveryNotification, string urlNonDeliveryNotification, string affiliateID)
        {
            UserName = userName;
            Password = password;
            Originator = originator ?? "Seq Server"; // use up to 11 Alphabetic characters - that's our default
            Recipients = recipients.Split(',');
            MessageText = messageText;
            DeferredDeliveryTime = DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
            FlashingSMS = Convert.ToString(flashingSMS);
            URLBufferedMessageNotification = urlBufferedMessageNotification;
            URLDeliveryNotification = urlDeliveryNotification;
            URLNonDeliveryNotification = urlNonDeliveryNotification;
            AffiliateID = affiliateID;
        }

        /// <summary>
        /// Returns the class as JSON object
        /// </summary>
        public string GetAsJson()
        {
            using (var stream = new MemoryStream())
            {
                var ser = new DataContractJsonSerializer(typeof(SendTextSMS));
                ser.WriteObject(stream, this);
                return Encoding.Default.GetString(stream.ToArray());
            }
        }
    }
}
