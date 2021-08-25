using SkillOrgBE.API.Context;
using SkillOrgBE.API.Entities;
using SkillOrgBE.API.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillOrgBE.API.Services
{
    public class LnRepository : ILnRepository
    {

        private readonly LnDBContext _context;

        public LnRepository(LnDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<SkillLevelThree> GetSkillsLevelThree()
        {
            return _context.SkillLevelThree.ToList();
        }

        /*SkillLevelThree*/
        public SkillLevelThree GetSkillLevelThree(int skillLevelThreeId)
        {
           
            return _context.SkillLevelThree
                .Where(s => s.SkillLevelThreeId == skillLevelThreeId).FirstOrDefault();
        }
        public void AddSkillLevelThree(SkillLevelThree skillLevelThree)
        {
            _context.SkillLevelThree.Add(skillLevelThree);
        }

        public void DeleteSkillLevelThree(SkillLevelThree skillLevelThree)
        {
            _context.SkillLevelThree.Remove(skillLevelThree);
        }

        /*SkillLevelTWO*/
        public IEnumerable<SkillLevelTwo> GetSkillsLevelTwo(bool includeLevelThreeSkills)
        {
            if (includeLevelThreeSkills)
            {
                return _context.SkillLevelTwo
                   .Include("SkillsLevelThree")
                   .ToList();
            }
            return _context.SkillLevelTwo.ToList();
        }

        public SkillLevelTwo GetSkillLevelTwo(int SkillLevelTwoId, bool includeLevelThreeSkills=true)
        {
            if (includeLevelThreeSkills)
            {
                return _context.SkillLevelTwo
                   .Include(x => x.SkillsLevelThree)
                   .Where(s => s.SkillLevelTwoId == SkillLevelTwoId).FirstOrDefault();
            }
            return _context.SkillLevelTwo
                .Where(s => s.SkillLevelTwoId == SkillLevelTwoId).FirstOrDefault();
        }

        public void AddSkillLevelTwo(SkillLevelTwo skillLevelTwo)
        {
            _context.SkillLevelTwo.Add(skillLevelTwo);
        }

        public void DeleteSkillLevelTwo(SkillLevelTwo skillLevelTwo)
        {
            _context.SkillLevelTwo.Remove(skillLevelTwo);
        }

        public bool SkillLevelTwoExists(int skillLevelTwoId)
        {
            return _context.SkillLevelTwo.Any(s => s.SkillLevelTwoId == skillLevelTwoId);
        }


        /*SkillLevelOne*/
        public bool SkillLevelOneExists(int skillLevelOneId)
        {
            return _context.SkillLevelOne.Any(s => s.SkillLevelOneId == skillLevelOneId);
        }


        public IEnumerable<SkillLevelOne> GetSkillsLevelOne(bool includeSubSkills)
        {
            if (includeSubSkills)
            {
                return _context.SkillLevelOne
                    .Include(lvlone => lvlone.SkillsLevelTwo)
                        .ThenInclude(lvltwo => lvltwo.SkillsLevelThree)
                    .ToList();
            }
            return _context.SkillLevelOne.ToList();
        }

        public SkillLevelOne GetSkillLevelOne(int SkillLevelOneId, bool includeSubSkills)
        {
            if (includeSubSkills)
            {
                return _context.SkillLevelOne
                    .Include(lvlone => lvlone.SkillsLevelTwo)
                        .ThenInclude(lvltwo => lvltwo.SkillsLevelThree)
                   .Where(s => s.SkillLevelOneId == SkillLevelOneId).FirstOrDefault();
            }
            return _context.SkillLevelOne
                .Where(s => s.SkillLevelOneId == SkillLevelOneId).FirstOrDefault();
        }

        public void AddSkillLevelOne(SkillLevelOne skillLevelOne)
        {
            _context.SkillLevelOne.Add(skillLevelOne);
        }

        public void DeleteSkillLevelOne(SkillLevelOne skillLevelOneEntity)
        {
            _context.SkillLevelOne.Remove(skillLevelOneEntity);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
