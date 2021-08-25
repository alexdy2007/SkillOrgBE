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
    [Route("api/skills/levelthree")]
    public class SkillLevelThreeController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly ILnRepository _lnRepository;
        private readonly IMapper _mapper;


        public SkillLevelThreeController(ILogger<SkillLevelThreeController> logger, ILnRepository lnRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _lnRepository = lnRepository ?? throw new ArgumentNullException(nameof(_lnRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        [HttpGet(Name = "GetLevelThreeSkills")]
        public IActionResult GetLevelThreeSkills()
        {
            var skillEntities = _lnRepository.GetSkillsLevelThree();

            return Ok(_mapper.Map<IEnumerable<SkillLevelThreeDto>>(skillEntities));
        }

        [HttpGet("{id}", Name = "GetLevelThreeSkill")]
        public IActionResult GetLevelThreeSkill(int id)
        {
            _logger.LogInformation($"Getting Skill Level Three with id {id}");
            var skillToReturn = _lnRepository.GetSkillLevelThree(id);

            if (skillToReturn == null)
            {
                _logger.LogInformation($"Skill Level Three with id {id} Not Found");
                return NotFound();
            }

            return Ok(_mapper.Map<SkillLevelThreeDto>(skillToReturn));
        }

        [HttpPost]
        public IActionResult CreateSkill([FromBody] SkillLevelThreeDto newSkill)
        {
            if (!_lnRepository.SkillLevelTwoExists(newSkill.SkillLevelTwoId))
            {
                return NotFound($"Skill Level Two with id {newSkill.SkillLevelTwoId} does not exist");
            }
            var skillLevelThreeToAdd = _mapper.Map<Entities.SkillLevelThree>(newSkill);
            _lnRepository.AddSkillLevelThree(skillLevelThreeToAdd);
            _lnRepository.Save();
            var newSkillDtoSaved = _mapper.Map<Models.SkillLevelThreeDto>(skillLevelThreeToAdd);


            return CreatedAtRoute(routeName: "GetLevelThreeSkill", routeValues: new { id = newSkillDtoSaved.SkillLevelThreeId }, value: newSkillDtoSaved);
        }

        [HttpPut]
        public IActionResult UpdateLevelThreeSkill([FromBody] SkillLevelThreeDto updateSkillLevelThree)
        {

            var skillInStore = _lnRepository.GetSkillLevelThree(updateSkillLevelThree.SkillLevelThreeId);

            if (skillInStore == null)
            {
                return NotFound($"Skill Level Three with id {updateSkillLevelThree.SkillLevelThreeId} does not exist");
            }

            if (!_lnRepository.SkillLevelTwoExists(updateSkillLevelThree.SkillLevelTwoId))
            {
                return NotFound($"Skill Level Two with id {updateSkillLevelThree.SkillLevelTwoId} does not exist");

            }

            _mapper.Map(updateSkillLevelThree, skillInStore);
            _lnRepository.Save();

            return NoContent();
        }


        [HttpPatch("{id}")]
        public IActionResult PartitalUpdateSkillLevelThree(int id, [FromBody] JsonPatchDocument<SkillLevelThreePatchDTO> patchDoc)
        {
            var skillInStoreEntity = _lnRepository.GetSkillLevelThree(id);

            if (skillInStoreEntity == null)
            {
                return NotFound($"Skill Level Three with ID : {id} not found" );
            }

            var skillInStoreDto = _mapper.Map<SkillLevelThreePatchDTO>(skillInStoreEntity);
            patchDoc.ApplyTo(skillInStoreDto);
            _mapper.Map(skillInStoreDto, skillInStoreEntity);
            _lnRepository.Save();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteSkillLevelThree(int id)
        {
            var skillInStoreEntity = _lnRepository.GetSkillLevelThree(id);
            if (skillInStoreEntity == null)
            {
                return NotFound($"Skill Level Three with ID : {id} not found");
            }

            _lnRepository.DeleteSkillLevelThree(skillInStoreEntity);
            _lnRepository.Save();
            return NoContent();

        }
    }
}