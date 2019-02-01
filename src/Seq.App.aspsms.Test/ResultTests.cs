using Seq.App.aspsms.Models;
using Xunit;

namespace Seq.App.aspsms.Tests
{
    public class ResultTests
    {
        [Fact]
        public void CheckValues()
        {
            // Act
            var data = Result.GetFromJson("{\"StatusCode\":\"1\",\"StatusInfo\":\"OK\"}");

            // Assert
            Assert.Equal("1", data.StatusCode);
            Assert.Equal("OK", data.StatusInfo);
            Assert.Null(data.Credits);
        }

        [Fact]
        public void CheckValuesWithCredits()
        {
            // Act
            var data = Result.GetFromJson("{\"StatusCode\":\"1\",\"StatusInfo\":\"OK\",\"Credits\":\"567\"}");

            // Assert
            Assert.Equal("1", data.StatusCode);
            Assert.Equal("OK", data.StatusInfo);
            Assert.Equal(567, data.Credits);
        }
    }
}