using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.DataTransferObjects
{
    public class AuditDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public long Timestamp { get; set; }
    }
}