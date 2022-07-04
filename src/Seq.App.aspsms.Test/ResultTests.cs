using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seq.App.aspsms.Models;

namespace Seq.App.aspsms.Tests
{
    [TestClass]
    public class ResultTests
    {
        [TestMethod]
        public void CheckValues()
        {
            // Act
            var data = Result.GetFromJson("{\"StatusCode\":\"1\",\"StatusInfo\":\"OK\"}");

            // Assert
            Assert.AreEqual("1", data.StatusCode);
            Assert.AreEqual("OK", data.StatusInfo);
            Assert.IsNull(data.Credits);
        }

        [TestMethod]
        public void CheckValuesWithCredits()
        {
            // Act
            var data = Result.GetFromJson("{\"StatusCode\":\"1\",\"StatusInfo\":\"OK\",\"Credits\":\"567\"}");

            // Assert
            Assert.AreEqual("1", data.StatusCode);
            Assert.AreEqual("OK", data.StatusInfo);
            Assert.AreEqual(567, data.Credits);
        }
    }
}