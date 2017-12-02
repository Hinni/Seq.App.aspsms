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
            var data = new Result("{\"StatusCode\":\"1\",\"StatusInfo\":\"OK\"}");

            Assert.AreEqual("1", data.StatusCode);
            Assert.AreEqual("OK", data.StatusInfo);
        }
    }
}
