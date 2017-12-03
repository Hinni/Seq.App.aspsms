using Seq.App.aspsms.Helpers;
using Xunit;

namespace Seq.App.aspsms.Tests
{
    public class OriginatorTests
    {
        [Fact]
        public void IsValidAlphabetic_fail()
        {
            // Arrange
            var value = "+41791234567";

            // Act
            var result = Originator.IsValidAlphabetic(value);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidAlphabetic_success()
        {
            // Arrange
            var value = "Seq Server";

            // Act
            var result = Originator.IsValidAlphabetic(value);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsValidPhoneNumber_fail()
        {
            // Arrange
            var value = "Seq Server";

            // Act
            var result = Originator.IsValidPhoneNumber(value);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidPhoneNumber_success()
        {
            // Arrange
            var value = "+41791234567";

            // Act
            var result = Originator.IsValidPhoneNumber(value);

            // Assert
            Assert.True(result);
        }
    }
}
