using System.ComponentModel.DataAnnotations;

namespace Application.Models.DataTransferObjects
{
    public class AuditCreationDto
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}