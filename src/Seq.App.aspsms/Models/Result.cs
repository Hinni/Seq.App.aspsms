using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Seq.App.aspsms.Models
{
    public class Result
    {
        public string StatusCode { get; set; }
        public string StatusInfo { get; set; }
        [DataMember(IsRequired = false)]
        public decimal? Credits { get; set; }

        public static Result GetFromJson(string json)
        {
            return JsonConvert.DeserializeObject<Result>(json);
        }
    }
}