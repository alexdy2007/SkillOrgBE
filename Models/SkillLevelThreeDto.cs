using System.ComponentModel.DataAnnotations;

namespace SkillOrgBE.API.Models
{

    public class SkillLevelThreePatchDTO
    {
        public virtual string SkillLevelThreeName { get; set; }
        public int SkillLevelTwoId { get; set; }

        [MaxLength(300, ErrorMessage="Description Should Not be above length 300 chars")]
        public string Description { get; set; }
        [MaxLength(300, ErrorMessage="Img Path Should Not be above length 300 chars")]
        public string ImgPath { get; set; }
    }

    public class SkillLevelThreeWithoutLevelTwo
    {
        public int SkillLevelThreeId { get; set; }
        public virtual string SkillLevelThreeName { get; set; }
        [MaxLength(300, ErrorMessage = "Description Should Not be above length 300 chars")]
        public string Description { get; set; }
        [MaxLength(300, ErrorMessage = "Img Path Should Not be above length 300 chars")]
        public string ImgPath { get; set; }
    }

    public class SkillLevelThreeDto: SkillLevelThreePatchDTO
    {
        [Required]
        public int SkillLevelThreeId { get; set; }

        [Required (ErrorMessage="Skill Should have a name")]
        public override string SkillLevelThreeName { get; set; }

    }


}