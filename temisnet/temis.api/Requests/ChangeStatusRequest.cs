using System.Text.Json.Serialization;

namespace temis.Api.Controllers.Models.Requests
{
    public class ChangeStatusRequest
    {

        [JsonPropertyName("id")]
        public long Id { get; set; }

      
        [JsonPropertyName("status")]
        public string Status { get; set; }

    }
        
    
}