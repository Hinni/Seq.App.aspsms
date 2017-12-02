using Seq.App.aspsms.Models;
using Seq.Apps;
using Seq.Apps.LogEvents;
using System;
using System.Net;

namespace Seq.App.aspsms
{
    [SeqApp("Notify by SMS (aspsms.ch)", Description = "Send a SMS to a mobile phone over aspsms.ch")]
    public class NotifyReactor : Reactor, ISubscribeTo<LogEventData>
    {
        private readonly string _postUrl = "https://json.aspsms.com/SendTextSMS";

        [SeqAppSetting(
            InputType = SettingInputType.Text,
            DisplayName = "Recipients",
            HelpText = "We recommend E.164 phone number formatting: [+][country code][subscriber number including area code] (eg. '+41780000000'). Multiple addresses are separated by a comma.")]
        public string Recipients { get; set; }

        [SeqAppSetting(
            IsOptional = true,
            InputType = SettingInputType.Text,
            DisplayName = "Originator",
            HelpText = "You can use a phone number or up to 11 Alphabetic characters (e.g. 'MYBUSINESS') as Originator. In order to use a phone number (e.g. '+4176000000') you must unlock it first.")]
        public string Originator { get; set; }

        [SeqAppSetting(
            InputType = SettingInputType.Text,
            DisplayName = "Userkey",
            HelpText = "Your ASPSMS Userkey.")]
        public string Username { get; set; }

        [SeqAppSetting(
            InputType = SettingInputType.Password,
            DisplayName = "Password",
            HelpText = "Your ASPSMS Password.")]
        public string Password { get; set; }

        [SeqAppSetting(
            IsOptional = true,
            DisplayName = "Flashing SMS",
            HelpText = "The message appears directly on the screen of the mobile phone. A flashing message isn't saved directly on the mobile phone. The recipient has to choose to save it. Otherwise the message irrevocably disappears from the screen.")]
        public bool? FlashingSMS { get; set; }

        [SeqAppSetting(
            IsOptional = true,
            DisplayName = "Log Status",
            HelpText = "Log transaction status after POST to aspsms.ch")]
        public bool? LogStatus { get; set; }

        [SeqAppSetting(
            IsOptional = true,
            InputType = SettingInputType.Text,
            DisplayName = "URLBufferedMessageNotification",
            HelpText = "URL that will be connected when a message is not delivered instantly and is buffered. The submitted TransactionReferenceNumber will added to the URL.")]
        public string URLBufferedMessageNotification { get; set; }

        [SeqAppSetting(
            IsOptional = true,
            InputType = SettingInputType.Text,
            DisplayName = "URLDeliveryNotification",
            HelpText = "URL that will be called when a message is delivered instantly. The submitted TransactionReferenceNumber will added to the URL.")]
        public string URLDeliveryNotification { get; set; }

        [SeqAppSetting(
            IsOptional = true,
            InputType = SettingInputType.Text,
            DisplayName = "URLNonDeliveryNotification",
            HelpText = "URL that will be connected when a message is not delivered. The submitted TransactionReferenceNumber will added to the URL.")]
        public string URLNonDeliveryNotification { get; set; }

        [SeqAppSetting(
            IsOptional = true,
            InputType = SettingInputType.Text,
            DisplayName = "AffiliateID",
            HelpText = "If you are a affiliate partner with ASPSMS you can provide your affiliate-id here.")]
        public string AffiliateID { get; set; }

        public void On(Event<LogEventData> evt)
        {
            // Create MessageText
            var message = $"{evt.Data.LocalTimestamp} {evt.Data.Level} {evt.Data.RenderedMessage}";

            // Fill in data
            var data = new SendTextSMS(
                Username, Password, Originator, Recipients, message, FlashingSMS.GetValueOrDefault(false),
                URLBufferedMessageNotification, URLDeliveryNotification, URLNonDeliveryNotification, AffiliateID);

            // Send SMS
            using (var client = new WebClient())
            {
                var result = client.UploadString(_postUrl, data.GetAsJson());

                if (!LogStatus.GetValueOrDefault(false))
                {
                    try
                    {
                        var obj = new Result(result);
                        Log.Information("SMS sent {StatusCode} {StatusInfo}", obj.StatusCode, obj.StatusInfo);
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "Can't parse status code");
                    }
                }
            }
        }
    }
}
