using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.DataTransferObjects
{
    public class ProjectDto
    {
        public string Id { get; set; }
        public string OwnerId { get; set; }
        public string FreelancerId { get; set; }

        public ProjectContentDto ProjectContent { get; set; }
    }
}