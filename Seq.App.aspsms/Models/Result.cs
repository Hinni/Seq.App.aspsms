using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Seq.App.aspsms.Models
{
    /// <summary>
    /// Needed JSON object to receive status results
    /// </summary>
    [DataContract]
    public class Result
    {
        [DataMember]
        public string StatusCode { get; private set; }
        [DataMember]
        public string StatusInfo { get; private set; }
        [DataMember]
        public decimal? Credits { get; private set; }

        public Result(string result)
        {
            using (var stream = new MemoryStream(Encoding.Default.GetBytes(result)))
            {
                stream.Position = 0;
                var ser = new DataContractJsonSerializer(typeof(Result));
                var obj = (Result)ser.ReadObject(stream);

                StatusCode = obj.StatusCode;
                StatusInfo = obj.StatusInfo;
                Credits = obj.Credits;
            }
        }
    }
}