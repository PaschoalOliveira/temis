using System;

namespace temis.Core.DTO
{
    public class ProcessDto
    {
        public string Status { get; set; }
        public DateTime StatusUpdate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}