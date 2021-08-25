using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillOrgBE.API.Profiles
{
    public class SkillProfiler: Profile
    {
        public SkillProfiler()
        {
            CreateMap<Entities.SkillLevelThree, Models.SkillLevelThreeDto>().ReverseMap();
            CreateMap<Entities.SkillLevelThree, Models.SkillLevelThreePatchDTO>().ReverseMap();

            CreateMap<Entities.SkillLevelTwo, Models.SkillLevelTwoDto>().ReverseMap();
            CreateMap<Entities.SkillLevelTwo, Models.SkillLevelTwoPatchDTO>().ReverseMap();

            CreateMap<Entities.SkillLevelOne, Models.SkillLevelOneDto>().ReverseMap();
            CreateMap<Entities.SkillLevelOne, Models.SkillLevelOneDto>().ReverseMap();
        }
    }
}
