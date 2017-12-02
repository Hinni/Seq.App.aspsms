using Seq.App.aspsms.Models;
using Xunit;

namespace Seq.App.aspsms.Tests
{
    public class SendTextSMSTests
    {
        [Fact]
        public void CheckJsonOutput()
        {
            // Arrange
            var data = new SendTextSMS("Userkey", "Password", "SEQ", "+41791234567,+41761234567", "Test Message", false, null, null, null, null);

            // Act
            var json = data.GetAsJson();

            // Assert
        }
    }
}
