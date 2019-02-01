using System.Runtime.Serialization;

namespace Seq.App.aspsms.Models
{
    public class Result
    {
        public string StatusCode { get; private set; }
        public string StatusInfo { get; private set; }
        [DataMember(IsRequired = false)]
        public decimal? Credits { get; private set; }
    }
}