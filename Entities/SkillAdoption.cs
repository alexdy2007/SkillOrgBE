using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkillOrgBE.API.Entities
{
    public class SkillAdoption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
