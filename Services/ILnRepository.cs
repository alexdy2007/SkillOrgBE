using SkillOrgBE.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillOrgBE.API.Services
{
    public interface ILnRepository
    {
        /*Skill Level Three*/
        IEnumerable<SkillLevelThree> GetSkillsLevelThree();
        SkillLevelThree GetSkillLevelThree(int skillLevelThreeId);
        public void AddSkillLevelThree(SkillLevelThree skillLevelThree);

        public void DeleteSkillLevelThree(SkillLevelThree skillLevelThreeEntity);

        /*Skill Level Two */
        IEnumerable<SkillLevelTwo> GetSkillsLevelTwo(bool includeLevelThreeSkills);
        SkillLevelTwo GetSkillLevelTwo(int SkillLevelTwoId, bool includeLevelThreeSkills);
        public void AddSkillLevelTwo(SkillLevelTwo skillLevelTwo);
        public void DeleteSkillLevelTwo(SkillLevelTwo skillLevelTwoEntity);

        /*Skill Level One*/
        IEnumerable<SkillLevelOne> GetSkillsLevelOne(bool includeSubSkills);
        SkillLevelOne GetSkillLevelOne(int SkillLevelOneId, bool includeSubSkills);
        public void AddSkillLevelOne(SkillLevelOne skillLevelOne);
        public void DeleteSkillLevelOne(SkillLevelOne skillLevelOneEntity);


        bool SkillLevelTwoExists(int SkillLevelTwoId);
        bool SkillLevelOneExists(int SkillLevelTwoId);
        bool Save();

        // SkillAdoption
        IEnumerable<SkillAdoption> GetSkillAdoption();


    }

    public interface ILnRepositoryWithoutEF : ILnRepository
    {
        public void UpdateSkillLevelThree(int SkillLevelThreeId, SkillLevelThree skillLevelThree);
        public void UpdateSkillLevelTwo(int SkillLevelTwoId, SkillLevelTwo skillLevelTwo);
        public void UpdateSkillLevelOne(int SkillLevelOneId, SkillLevelOne skillLevelOne);


    }

}
