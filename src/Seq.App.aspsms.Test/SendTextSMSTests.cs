using Seq.App.aspsms.Models;
using System;
using Xunit;

namespace Seq.App.aspsms.Tests
{
    public class SendTextSMSTests
    {
        [Fact]
        public void CheckJsonOutput()
        {
            // Arrange
            var data = new SendTextSMS(new DateTime(2019, 02, 01, 21, 53, 00), "Userkey", "Password", "SEQ", "+41791234567,+41761234567", "Test Message", false, null, null, null, null, null);

            // Act
            var json = data.GetAsJson();

            // Assert
            Assert.Equal("SEQ", data.Originator);
            Assert.Equal("{\"UserName\":\"Userkey\",\"Password\":\"Password\",\"Originator\":\"SEQ\",\"Recipients\":[\"+41791234567\",\"+41761234567\"],\"MessageText\":\"Test Message\",\"DeferredDeliveryTime\":\"2019-02-01T20:53:00.000Z\",\"FlashingSMS\":\"False\"}", json);
        }

        [Fact]
        public void CheckOriginator()
        {
            // Act
            var data = new SendTextSMS(new DateTime(2019, 02, 01, 21, 53, 00), "Userkey", "Password", "+41791234567", "+41791234567,+41761234567", "Test Message", false, null, null, null, null, null);

            // Assert
            Assert.Equal("+41791234567", data.Originator);
        }

        [Fact]
        public void CheckInvalidPhoneNumberOriginator()
        {
            // Act
            var data = new SendTextSMS(new DateTime(2019, 02, 01, 21, 53, 00), "Userkey", "Password", "+41 79 123 45 67", "+41791234567,+41761234567", "Test Message", false, null, null, null, null, null);

            // Assert
            Assert.Equal("Seq Server", data.Originator);
        }

        [Fact]
        public void CheckOriginatorWithOversize()
        {
            // Act
            var data = new SendTextSMS(new DateTime(2019, 02, 01, 21, 53, 00), "Userkey", "Password", null, "+41791234567,+41761234567", "Test Message", false, null, null, null, null, "SeqInstance001");

            // Assert
            Assert.Equal("SeqInstance", data.Originator);
        }
    }
}