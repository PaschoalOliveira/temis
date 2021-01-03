using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using temis.Api.Models.Convert;

namespace temis.Api.Models.ViewModel
{

    public class JudgmentViewModel
    {

        [DataType(DataType.Date)]
        [JsonConverter(typeof(JsonDateConverter))]
        public DateTime JudgmentDate { get; set; }
        public string Veredict { get; set; }

    }
}