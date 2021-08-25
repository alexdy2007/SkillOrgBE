/*using SkillOrgBE.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace SkillOrgBE.API
{
    public class SkillsDataStore
    {

        public List<SkillsDto> Skills {get; set;}

        public static SkillsDataStore Current {get;} = new SkillsDataStore();

        public void AddToCurrentStore(SkillsDto newSkill){
            Skills.Add(newSkill);
        }

        public SkillsDataStore()
        {
            Skills = new List<SkillsDto>()
            {
                new SkillsDto() {SkillID=1, Skill="python", SkillSubTypeID=1, Description="high level language", ImgPath="www.python.org/logo"},
                new SkillsDto() {SkillID=2 ,Skill="c#", SkillSubTypeID=2, Description="enterpise .net language", ImgPath="www.microsoft.org/c#/logo"}
            };

        }

        public int GetMaxSkillID()
        {
            if (Skills.Count==0){
                return 1;
            }
            SkillsDto maxSkillID = Skills.OrderByDescending(x => x.SkillID).First();
            return maxSkillID.SkillID;
        }
    }
}*/