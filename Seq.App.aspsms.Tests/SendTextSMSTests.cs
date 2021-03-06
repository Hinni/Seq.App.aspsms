﻿using Seq.App.aspsms.Models;
using Xunit;

namespace Seq.App.aspsms.Tests
{
    public class SendTextSMSTests
    {
        [Fact]
        public void CheckJsonOutput()
        {
            // Arrange
            var data = new SendTextSMS("Userkey", "Password", "SEQ", "+41791234567,+41761234567", "Test Message", false, null, null, null, null, null);

            // Act
            var json = data.GetAsJson();

            // Assert
            Assert.Equal("SEQ", data.Originator);
            Assert.NotEmpty(json);
        }

        [Fact]
        public void CheckOriginator()
        {
            // Arrange

            // Act
            var data = new SendTextSMS("Userkey", "Password", "+41791234567", "+41791234567,+41761234567", "Test Message", false, null, null, null, null, null);

            // Assert
            Assert.Equal("+41791234567", data.Originator);
        }

        [Fact]
        public void CheckInvalidPhoneNumberOriginator()
        {
            // Arrange

            // Act
            var data = new SendTextSMS("Userkey", "Password", "+41 79 123 45 67", "+41791234567,+41761234567", "Test Message", false, null, null, null, null, null);

            // Assert
            Assert.Equal("Seq Server", data.Originator);
        }

        [Fact]
        public void CheckOriginatorWithOversize()
        {
            // Arrange

            // Act
            var data = new SendTextSMS("Userkey", "Password", null, "+41791234567,+41761234567", "Test Message", false, null, null, null, null, "SeqInstance001");

            // Assert
            Assert.Equal("SeqInstance", data.Originator);
        }
    }
}
