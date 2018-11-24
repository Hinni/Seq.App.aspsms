using Seq.App.aspsms.Models;
using Seq.Apps;
using Seq.Apps.LogEvents;
using System;
using System.Net;

namespace Seq.App.aspsms
{
    [SeqApp("Notify by SMS (ASPSMS)", Description = "Send a SMS to a mobile phone over aspsms.ch provider.")]
    public class NotifyReactor : Reactor, ISubscribeTo<LogEventData>
    {
        private readonly string _postUrl = "https://json.aspsms.com/";

        [SeqAppSetting(
            InputType = SettingInputType.Text,
            DisplayName = "Recipients",
            HelpText = "We recommend E.164 phone number formatting: [+][country code][subscriber number including area code] (eg. '+41780000000'). Multiple recipients are separated by a comma.")]
        public string Recipients { get; set; }

        [SeqAppSetting(
            IsOptional = true,
            InputType = SettingInputType.Text,
            DisplayName = "Originator",
            HelpText = "You can use a phone number or up to 11 Alphabetic characters (e.g. 'MYBUSINESS') as Originator. In order to use a phone number (e.g. '+4176000000') you must unlock it first. Default value is your Seq instance name.")]
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
            InputType = SettingInputType.Checkbox,
            DisplayName = "Flashing SMS",
            HelpText = "The message appears directly on the screen of the mobile phone. A flashing message isn't saved directly on the mobile phone. The recipient has to choose to save it. Otherwise the message irrevocably disappears from the screen.")]
        public bool FlashingSMS { get; set; }

        [SeqAppSetting(
            InputType = SettingInputType.Checkbox,
            DisplayName = "Log transmission status to Seq",
            HelpText = "Log transmission status after POST to local Seq instance.")]
        public bool LogStatus { get; set; }

        [SeqAppSetting(
            InputType = SettingInputType.Checkbox,
            DisplayName = "Include credits",
            HelpText = "Add available credits to every transmission status.")]
        public bool LogAvailableCredits { get; set; }

        [SeqAppSetting(
            IsOptional = true,
            InputType = SettingInputType.Text,
            DisplayName = "URL BufferedMessage",
            HelpText = "URL that will be connected when a message is not delivered instantly and is buffered. The submitted TransactionReferenceNumber will added to the URL.")]
        public string URLBufferedMessageNotification { get; set; }

        [SeqAppSetting(
            IsOptional = true,
            InputType = SettingInputType.Text,
            DisplayName = "URL Delivery",
            HelpText = "URL that will be called when a message is delivered instantly. The submitted TransactionReferenceNumber will added to the URL.")]
        public string URLDeliveryNotification { get; set; }

        [SeqAppSetting(
            IsOptional = true,
            InputType = SettingInputType.Text,
            DisplayName = "URL NonDelivery",
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
            var message = $"{evt.Data.LocalTimestamp.LocalDateTime} ({evt.Data.Level}) {evt.Data.RenderedMessage}";

            // Fill in data
            var data = new SendTextSMS(
                Username, Password, Originator, Recipients, message, FlashingSMS,
                URLBufferedMessageNotification, URLDeliveryNotification, URLNonDeliveryNotification, AffiliateID, Host.InstanceName);

            // Send SMS
            using (var client = new WebClient())
            {
                try
                {
                    var result = client.UploadString($"{_postUrl}SendTextSMS", data.GetAsJson());

                    if (!LogStatus)
                    {
                        return;
                    }

                    try
                    {
                        var obj = new Result(result);

                        if (LogAvailableCredits)
                        {
                            var credits = new CheckCredits(Username, Password);
                            var creditResult = new Result(client.UploadString($"{_postUrl}CheckCredits", credits.GetAsJson()));
                            Log.Information("SMS sent with {StatusCode} {StatusInfo} ({AvailableCredits} Credits left)", obj.StatusCode, obj.StatusInfo, creditResult.Credits);
                        }
                        else
                        {
                            Log.Information("SMS sent with {StatusCode} {StatusInfo}", obj.StatusCode, obj.StatusInfo);
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "Can't parse status code from result", result);
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "There was a problem sending SMS");
                }
            }
        }
    }
}