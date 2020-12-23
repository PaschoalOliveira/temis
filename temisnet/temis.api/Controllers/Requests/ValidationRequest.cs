using System.Text.Json.Serialization;

namespace temis.Api.Controllers.Models.Requests
{
    public class ValidationRequest
    {

        [JsonPropertyName("cpf")]
        public string Cpf { get; set; }

      
        [JsonPropertyName("password")]
        public string Password { get; set; }

    }
        
    
}