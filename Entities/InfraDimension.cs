using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkillOrgBE.Entities
{
    public class InfrastructureDimension
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InfrastructureId { get; set; }

        [Required]
        [MaxLength(50)]
        public string InfrastructureName { get; set; }
    }
}
