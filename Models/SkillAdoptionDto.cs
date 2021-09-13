using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkillOrgBE.API.Models
{

    public class SkillAdoptionDTO
    {
        public int SkillAdoptionId { get; set; }

        [Required]
        [MaxLength(50)]
        public string SkillAdoptionName { get; set; }

        [Required]
        public int SkillAdoptionLevel { get; set; }

        [MaxLength(300)]
        public string SkillAdoptionDescription { get; set; }

    }
}