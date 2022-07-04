using System.Text.Json;

namespace Seq.App.aspsms.Models
{
    public class CheckCredits
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public CheckCredits(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string GetAsJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull });
        }
    }
}