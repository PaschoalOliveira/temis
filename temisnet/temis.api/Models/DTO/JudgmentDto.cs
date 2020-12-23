using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace temis.Api.Models.DTO.JudgmentDto
{
    public class JudgmentDto
    {

        [DataType(DataType.Date)]
     //   [JsonConverter(typeof(JsonDateConverter))]
        public DateTime JudgmentDate { get; set; }
        public string Veredict { get; set; }

    }
}