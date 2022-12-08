using System.Text.Json;

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
            var json = JsonSerializer.Serialize(data);

            // Assert
            Assert.Equal("Userkey", data.UserName);
            Assert.Equal("Password", data.Password);
            Assert.NotEmpty(json);
        }
    }
}