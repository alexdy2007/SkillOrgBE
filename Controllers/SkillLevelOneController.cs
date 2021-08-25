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
    [Route("api/skills/levelone")]
    public class SkillLevelOneController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ILnRepository _lnRepository;
        private readonly IMapper _mapper;


        public SkillLevelOneController(ILogger<SkillLevelOneController> logger, ILnRepository lnRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _lnRepository = lnRepository ?? throw new ArgumentNullException(nameof(_lnRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        [HttpGet(Name = "GetLevelOneSkills")]
        public IActionResult GetLevelOneSkills([FromQuery(Name = "incsubskills")] bool includeSubSkills = true)
        {
            var skillEntities = _lnRepository.GetSkillsLevelOne(includeSubSkills);

            return Ok(_mapper.Map<IEnumerable<SkillLevelOneDto>>(skillEntities));
        }

        [HttpGet("{id}", Name = "GetSkillLevelOne")]
        public IActionResult GetLevelOneSkill(int id)
        {
            _logger.LogInformation($"Getting Skill Level One with id {id}");
            var skillToReturn = _lnRepository.GetSkillLevelOne(id, includeSubSkills:false);

            if (skillToReturn == null)
            {
                _logger.LogInformation($"Skill Level One with id {id} Not Found");
                return NotFound();
            }

            return Ok(_mapper.Map<SkillLevelOneDto>(skillToReturn));
        }

        

        [HttpPost]
        public IActionResult CreateLevelTwoSkill([FromBody] SkillLevelOneDto newSkill)
        {

            var skillLevelOneToAdd = _mapper.Map<Entities.SkillLevelOne>(newSkill);
            _lnRepository.AddSkillLevelOne(skillLevelOneToAdd);
            _lnRepository.Save();
            var newSkillDtoSaved = _mapper.Map<Models.SkillLevelOneDto>(skillLevelOneToAdd);

            return CreatedAtRoute(routeName: "GetSkillLevelOne", routeValues: new { id = newSkillDtoSaved.SkillLevelOneId }, value: newSkillDtoSaved);
        }

        
        [HttpPut]
        public IActionResult UpdateLevelOneSkill([FromBody] SkillLevelOneDto updateSkillLevelOne)
        {

            var skillInStore = _lnRepository.GetSkillLevelOne(updateSkillLevelOne.SkillLevelOneId, includeSubSkills: false);

            if (skillInStore == null)
            {
                return NotFound($"Skill Level One with id {updateSkillLevelOne.SkillLevelOneId} does not exist");
            }

            _mapper.Map(updateSkillLevelOne, skillInStore);
            _lnRepository.Save();

            return NoContent();
        }

        

        [HttpPatch("{id}")]
        public IActionResult PartitalUpdateSkillLevelOne(int id, [FromBody] JsonPatchDocument<SkillLevelOneDto> patchDoc)
        {
            var skillInStoreEntity = _lnRepository.GetSkillLevelOne(id, includeSubSkills: false);

            if (skillInStoreEntity == null)
            {
                return NotFound($"Skill Level One with ID : {id} not found");
            }

            var skillInStoreDto = _mapper.Map<SkillLevelOneDto>(skillInStoreEntity);
            patchDoc.ApplyTo(skillInStoreDto);
            _mapper.Map(skillInStoreDto, skillInStoreEntity);
            _lnRepository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSkillLevelOne(int id)
        {
            var skillInStoreEntity = _lnRepository.GetSkillLevelOne(id, includeSubSkills: false);
            if (skillInStoreEntity == null)
            {
                return NotFound($"Skill Level One with ID : {id} not found");
            }

            _lnRepository.DeleteSkillLevelOne(skillInStoreEntity);
            _lnRepository.Save();
            return NoContent();

        }
    }
}
