using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seq.App.aspsms.Models;
using System;

namespace Seq.App.aspsms.Tests
{
    [TestClass]
    public class SendTextSMSTests
    {
        [TestMethod]
        public void CheckJsonOutput()
        {
            // Arrange
            var data = new SendTextSMS(new DateTime(2019, 02, 01, 20, 53, 00, DateTimeKind.Utc), "Userkey", "Password", "SEQ", "+41791234567,+41761234567", "Test Message", false, null, null, null, null, null);

            // Act
            var json = data.GetAsJson();

            // Assert
            Assert.AreEqual("SEQ", data.Originator);
            Assert.AreEqual("{\"UserName\":\"Userkey\",\"Password\":\"Password\",\"Originator\":\"SEQ\",\"Recipients\":[\"+41791234567\",\"+41761234567\"],\"MessageText\":\"Test Message\",\"DeferredDeliveryTime\":\"2019-02-01T20:53:00.000Z\",\"FlashingSMS\":\"False\"}", json);
        }

        [TestMethod]
        public void CheckOriginator()
        {
            // Act
            var data = new SendTextSMS(new DateTime(2019, 02, 01, 20, 53, 00, DateTimeKind.Utc), "Userkey", "Password", "+41791234567", "+41791234567,+41761234567", "Test Message", false, null, null, null, null, null);

            // Assert
            Assert.AreEqual("+41791234567", data.Originator);
        }

        [TestMethod]
        public void CheckInvalidPhoneNumberOriginator()
        {
            // Act
            var data = new SendTextSMS(new DateTime(2019, 02, 01, 20, 53, 00, DateTimeKind.Utc), "Userkey", "Password", "+41 79 123 45 67", "+41791234567,+41761234567", "Test Message", false, null, null, null, null, null);

            // Assert
            Assert.AreEqual("Seq Server", data.Originator);
        }

        [TestMethod]
        public void CheckOriginatorWithOversize()
        {
            // Act
            var data = new SendTextSMS(new DateTime(2019, 02, 01, 20, 53, 00, DateTimeKind.Utc), "Userkey", "Password", null, "+41791234567,+41761234567", "Test Message", false, null, null, null, null, "SeqInstance001");

            // Assert
            Assert.AreEqual("SeqInstance", data.Originator);
        }
    }
}