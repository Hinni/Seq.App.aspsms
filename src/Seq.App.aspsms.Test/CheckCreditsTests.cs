using Newtonsoft.Json;
using Seq.App.aspsms.Models;
using Xunit;

namespace Seq.App.aspsms.Tests
{
    public class CheckCreditsTests
    {
        [Fact]
        public void CheckJsonOutput()
        {
            // Arrange
            var data = new CheckCredits("Userkey", "Password");

            // Act
            var json = JsonConvert.SerializeObject(data);

            // Assert
            Assert.Equal("Userkey", data.UserName);
            Assert.Equal("Password", data.Password);
            Assert.NotEmpty(json);
        }
    }
}