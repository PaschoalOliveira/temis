using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using temis.Api.Models.Convert;

namespace temis.Api.Models.DTO
{

    public class JudgmentDto
    {

        [DataType(DataType.Date)]
     //   [JsonConverter(typeof(JsonDateConverter))]
        public DateTime JudgmentDate { get; set; }
        public string Veredict { get; set; }

    }
}