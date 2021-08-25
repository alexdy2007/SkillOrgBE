using System;
using Microsoft.AspNetCore.JsonPatch;
using System.ComponentModel.DataAnnotations;
using SkillOrgBE.API.Models;
using Microsoft.Extensions.Logging;
using SkillOrgBE.API.Services;
using SkillOrgBE.API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;

namespace SkillOrgBE.API.Controllers
{
    [ApiController]
    [Route("api/skills/leveltwo")]
    public class SkillLevelTwoController : ControllerBase
    { 
        private readonly ILogger _logger;
        private readonly ILnRepository _lnRepository;
        private readonly IMapper _mapper;


        public SkillLevelTwoController(ILogger<SkillLevelTwoController> logger, ILnRepository lnRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _lnRepository = lnRepository ?? throw new ArgumentNullException(nameof(_lnRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        [HttpGet(Name = "GetLevelTwoSkills")]
        public IActionResult GetLevelTwoSkills([FromQuery(Name = "inclevelthreeskills")] bool includeLevelThreeSkills=true)
        {
            var skillEntities = _lnRepository.GetSkillsLevelTwo(includeLevelThreeSkills);

            return Ok(_mapper.Map<IEnumerable<SkillLevelTwoDto>>(skillEntities));
        }

        [HttpGet("{id}", Name = "GetLevelTwoSkill")]
        public IActionResult GetLevelTwoSkill(int id)
        {
            _logger.LogInformation($"Getting Skill with id {id}");
            var skillToReturn = _lnRepository.GetSkillLevelTwo(id, includeLevelThreeSkills:false);

            if (skillToReturn == null)
            {
                _logger.LogInformation($"Skill Level Two with id {id} Not Found");
                return NotFound();
            }

            return Ok(_mapper.Map<SkillLevelTwoDto>(skillToReturn));
        }

        [HttpPost]
        public IActionResult CreateLevelTwoSkill([FromBody] SkillLevelTwoDto newSkill)
        {
            if (!_lnRepository.SkillLevelOneExists(newSkill.SkillLevelOneId))
            {
                return NotFound($"Skill Level One with id {newSkill.SkillLevelOneId} does not exist");
            }
            var skillLevelTwoToAdd = _mapper.Map<Entities.SkillLevelTwo>(newSkill);
            _lnRepository.AddSkillLevelTwo(skillLevelTwoToAdd);
            _lnRepository.Save();
            var newSkillDtoSaved = _mapper.Map<Models.SkillLevelTwoDto>(skillLevelTwoToAdd);

            return CreatedAtRoute(routeName: "GetLevelTwoSkill", routeValues: new { id = newSkillDtoSaved.SkillLevelTwoId }, value: newSkillDtoSaved);
        }

        
        [HttpPut]
        public IActionResult UpdateLevelTwoSkill([FromBody] SkillLevelTwoDto updateSkillLevelTwo)
        {

            var skillInStore = _lnRepository.GetSkillLevelTwo(updateSkillLevelTwo.SkillLevelTwoId, includeLevelThreeSkills:false);

            if (skillInStore == null)
            {
                return NotFound($"Skill Level Two with id {updateSkillLevelTwo.SkillLevelTwoId} does not exist");
            }

            if (!_lnRepository.SkillLevelOneExists(updateSkillLevelTwo.SkillLevelOneId))
            {
                return NotFound($"Skill Level One with id {updateSkillLevelTwo.SkillLevelTwoId} does not exist");

            }

            _mapper.Map(updateSkillLevelTwo, skillInStore);
            _lnRepository.Save();

            return NoContent();
        }


     
        [HttpPatch("{id}")]
        public IActionResult PartitalUpdateSkillLevelTwo(int id, [FromBody] JsonPatchDocument<SkillLevelTwoPatchDTO> patchDoc)
        {
            var skillInStoreEntity = _lnRepository.GetSkillLevelTwo(id, includeLevelThreeSkills:false);

            if (skillInStoreEntity == null)
            {
                return NotFound($"Skill Level Two with ID : {id} not found");
            }

            var skillInStoreDto = _mapper.Map<SkillLevelTwoDto>(skillInStoreEntity);
            patchDoc.ApplyTo(skillInStoreDto);
            _mapper.Map(skillInStoreDto, skillInStoreEntity);
            _lnRepository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSkillLevelTwo(int id)
        {
            var skillInStoreEntity = _lnRepository.GetSkillLevelTwo(id, includeLevelThreeSkills:false);
            if (skillInStoreEntity == null)
            {
                return NotFound($"Skill Level Two with ID : {id} not found");
            }

            _lnRepository.DeleteSkillLevelTwo(skillInStoreEntity);
            _lnRepository.Save();
            return NoContent();

        }
    }
}
