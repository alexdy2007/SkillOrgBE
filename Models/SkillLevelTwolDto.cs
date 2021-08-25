using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkillOrgBE.API.Models
{

    public class SkillLevelTwoPatchDTO
    {
        public virtual string SkillLevelTwoName { get; set; }

        [MaxLength(300, ErrorMessage = "Description Should Not be above length 300 chars")]
        public string Description { get; set; }
        public int SkillLevelOneId { get; set; }

        public ICollection<SkillLevelThreeDto> SkillsLevelThree { get; set; } = new List<SkillLevelThreeDto>();

    }

    public class SkillLevelTwoWithoutLevels
    {
        public int SkillLevelTwoId { get; set; }
        public string SkillLevelTwoName { get; set; }
        [MaxLength(300, ErrorMessage = "Description Should Not be above length 300 chars")]
        public string Description { get; set; }
        public int SkillLevelOneId { get; set; }

    }

    public class SkillLevelTwoDto : SkillLevelTwoPatchDTO
    {
        [Required]
        public int SkillLevelTwoId { get; set; }

        [Required(ErrorMessage = "Skill Should have a name")]
        public override string SkillLevelTwoName { get; set; }

    }


}