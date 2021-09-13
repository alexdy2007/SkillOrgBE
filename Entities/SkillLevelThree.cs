
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SkillOrgBE.API.Entities
{
    public class SkillLevelThree
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillLevelThreeId{ get; set; }

        [Required]
        [MaxLength(50)]
        public string SkillLevelThreeName { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
        public string ImgPath { get; set; }

        [ForeignKey("SkillLevelTwoId")]
        public SkillLevelTwo SkillLevelTwo{ get; set; }
        public int SkillLevelTwoId { get; set; }

        [ForeignKey("SkillAdoptionId")]
        public SkillAdoption SkillAdoption {get; set; }
        public int SkillAdoptionId {get; set; }

    }
}
