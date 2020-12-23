using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using temis.Core.Models;

namespace temis.Api.Models.DTO
{
    public class ProcessDto
    {
        public string Number { get; set; }
        
        [DataType(DataType.Date)]
    //    [JsonConverter(typeof(JsonDateConverter))]
        public DateTime CreationDate { get; set; }
        public string Status { get; set; }

        [DataType(DataType.Date)]
    //    [JsonConverter(typeof(JsonDateConverter))]
        public DateTime StatusUpdate { get; set; }
        
        public IEnumerable<JudgmentDto> Judgments {get; set;} 

    }
}