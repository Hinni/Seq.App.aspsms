﻿using System;
using System.Text.Json;

namespace Seq.App.aspsms.Models
{
    public class SendTextSMS
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Originator { get; private set; }
        public string[] Recipients { get; private set; }
        public string MessageText { get; private set; }
        public string DeferredDeliveryTime { get; private set; }
        public string FlashingSMS { get; private set; }
        public string URLBufferedMessageNotification { get; private set; }
        public string URLDeliveryNotification { get; private set; }
        public string URLNonDeliveryNotification { get; private set; }
        public string AffiliateID { get; private set; }

        public SendTextSMS(DateTime deferredDeliveryTime, string userName, string password, string originator, string recipients, string messageText, bool flashingSMS, string urlBufferedMessageNotification, string urlDeliveryNotification, string urlNonDeliveryNotification, string affiliateID, string instanceName)
        {
            UserName = userName;
            Password = password;
            Originator = originator;
            Recipients = recipients.Split(',');
            MessageText = messageText;
            DeferredDeliveryTime = deferredDeliveryTime.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
            FlashingSMS = Convert.ToString(flashingSMS);
            URLBufferedMessageNotification = urlBufferedMessageNotification;
            URLDeliveryNotification = urlDeliveryNotification;
            URLNonDeliveryNotification = urlNonDeliveryNotification;
            AffiliateID = affiliateID;

            // Is Originator empty? - set default value to Seq instance name
            if (string.IsNullOrWhiteSpace(Originator))
            {
                Originator = instanceName.Length > 11 ? instanceName.Substring(0, 11) : instanceName;
            }

            // Use up to 11 Alphabetic characters or a phone number
            if (Helpers.Originator.IsValidPhoneNumber(Originator))
            {
                // NOOP - later we check here if the phone number is unlocked
            }
            else if (Helpers.Originator.IsValidAlphabetic(Originator))
            {
                // NOOP
            }
            else
            {
                // Fallback - we use a default value
                Originator = "Seq Server";
            }
        }

        public string GetAsJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull });
        }
    }
}