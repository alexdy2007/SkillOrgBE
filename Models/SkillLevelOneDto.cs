using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkillOrgBE.API.Models
{

    public class SkillLevelOnePatchDTO
    {
        public virtual string SkillLevelOneName { get; set; }
        [MaxLength(300, ErrorMessage = "Description Should Not be above length 300 chars")]
        public string Description { get; set; }
        public ICollection<SkillLevelTwoDto> SkillsLevelTwo { get; set; } = new List<SkillLevelTwoDto>();

    }

    public class SkillLevelOneWithoutLevels
    {
        public int SkillLevelOneId { get; set; }
        public string SkillLevelOneName { get; set; }
        [MaxLength(300, ErrorMessage = "Description Should Not be above length 300 chars")]
        public string Description { get; set; }

    }

    public class SkillLevelOneDto : SkillLevelOnePatchDTO
    {
        [Required]
        public int SkillLevelOneId { get; set; }

        [Required(ErrorMessage = "Skill Should have a name")]
        public override string SkillLevelOneName { get; set; }

    }


}