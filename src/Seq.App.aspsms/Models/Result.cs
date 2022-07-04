using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

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
            return JsonSerializer.Deserialize<Result>(json, new JsonSerializerOptions { NumberHandling = JsonNumberHandling.AllowReadingFromString });
        }

        public string GetAsJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, NumberHandling = JsonNumberHandling.WriteAsString });
        }
    }
}