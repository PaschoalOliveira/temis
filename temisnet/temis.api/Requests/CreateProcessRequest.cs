using System.Text.Json.Serialization;

namespace temis.api.Requests
{
    public class CreateProcessRequest
    {

        [JsonPropertyName("number")]
        public string Number { get; set; }
    }
}