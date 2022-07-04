using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seq.App.aspsms.Helpers;

namespace Seq.App.aspsms.Tests
{
    [TestClass]
    public class OriginatorTests
    {
        [TestMethod]
        public void IsValidAlphabetic_fail()
        {
            // Arrange
            var value = "+41791234567";

            // Act
            var result = Originator.IsValidAlphabetic(value);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidAlphabetic_success()
        {
            // Arrange
            var value = "Seq Server";

            // Act
            var result = Originator.IsValidAlphabetic(value);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidPhoneNumber_fail()
        {
            // Arrange
            var value = "Seq Server";

            // Act
            var result = Originator.IsValidPhoneNumber(value);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidPhoneNumber_success()
        {
            // Arrange
            var value = "+41791234567";

            // Act
            var result = Originator.IsValidPhoneNumber(value);

            // Assert
            Assert.IsTrue(result);
        }
    }
}