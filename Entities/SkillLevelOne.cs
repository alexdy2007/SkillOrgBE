using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkillOrgBE.API.Entities
{
    public class SkillLevelOne
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillLevelOneId { get; set; }

        [Required]
        [MaxLength(50)]
        public string SkillLevelOneName { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public List<SkillLevelTwo> SkillsLevelTwo { get; set; }

    }
}
