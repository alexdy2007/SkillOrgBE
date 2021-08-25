using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkillOrgBE.API.Entities
{
    public class SkillLevelTwo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillLevelTwoId { get; set; }
        [Required]
        [MaxLength(50)]
        public string SkillLevelTwoName { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }

        public List<SkillLevelThree> SkillsLevelThree { get; set; }

        [ForeignKey("SkillLevelOneId")]
        public SkillLevelOne SkillLevelOne { get; set; }
        public int SkillLevelOneId { get; set; }
    }
}
