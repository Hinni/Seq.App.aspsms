using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seq.App.aspsms.Models;

namespace Seq.App.aspsms.Tests
{
    [TestClass]
    public class CheckCreditsTests
    {
        [TestMethod]
        public void CheckJsonOutput()
        {
            // Arrange
            var data = new CheckCredits("Userkey", "Password");

            // Act
            var json = data.GetAsJson();

            // Assert
            Assert.AreEqual("Userkey", data.UserName);
            Assert.AreEqual("Password", data.Password);
            Assert.AreEqual("{\"UserName\":\"Userkey\",\"Password\":\"Password\"}", json);
        }
    }
}