using System.Text.Json.Serialization;

namespace temis.Api.Controllers.Models.Requests
{
    public class EditPasswordRequest
    {

        [JsonPropertyName("id")]
        public long Id { get; set; }

      
        [JsonPropertyName("password")]
        public string Password { get; set; }

    }
        
    
}