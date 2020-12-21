using System;
using System.ComponentModel.DataAnnotations;

namespace temis.Core.DTO
{
    public class ProcessDto
    {
        public string Status { get; set; }

        [Display(Name="status_update")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{dd/mm/yyyy}", ApplyFormatInEditMode=true)]  
        public DateTime StatusUpdate { get; set; }

        public DateTime CreationDate { get; set; }
        public string Number { get; set; }
    }
}