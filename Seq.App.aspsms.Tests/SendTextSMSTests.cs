using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seq.App.aspsms.Models;

namespace Seq.App.aspsms.Tests
{
    [TestClass]
    public class SendTextSMSTests
    {
        [TestMethod]
        public void CheckJsonOutput()
        {
            var data = new SendTextSMS("Userkey", "Password", "SEQ", "+41791234567,+41761234567", "Test Message", false, null, null, null, null);
            var json = data.GetAsJson();
        }
    }
}
