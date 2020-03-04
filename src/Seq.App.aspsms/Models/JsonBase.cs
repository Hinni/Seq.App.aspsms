using Newtonsoft.Json;

namespace Seq.App.aspsms.Models
{
    public abstract class JsonBase
    {
        public string GetAsJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
        }
    }
}