using Seq.App.aspsms.Models;
using Xunit;

namespace Seq.App.aspsms.Tests
{
    public class ResultTests
    {
        [Fact]
        public void CheckValues()
        {
            // Arrange

            // Act
            var data = new Result("{\"StatusCode\":\"1\",\"StatusInfo\":\"OK\"}");

            // Assert
            Assert.Equal("1", data.StatusCode);
            Assert.Equal("OK", data.StatusInfo);
        }
    }
}
