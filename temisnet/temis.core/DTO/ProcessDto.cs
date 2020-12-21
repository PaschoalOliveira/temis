using System;

namespace temis.Core.DTO
{
    public class ProcessDto
    {
        public string Status;
        public DateTime StatusUpdate;
        public DateTime CreationDate { get; set; }
    }
}