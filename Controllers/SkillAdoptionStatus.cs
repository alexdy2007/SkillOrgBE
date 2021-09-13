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
    [Route("api/skills/skilladoption")]
    public class SkillAdoptionController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ILnRepository _lnRepository;
        private readonly IMapper _mapper;
    

        public SkillAdoptionController(ILogger<SkillAdoptionController> logger, ILnRepository lnRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _lnRepository = lnRepository ?? throw new ArgumentNullException(nameof(_lnRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        [HttpGet(Name = "GetSkillAdoptionTbl")]
        public IActionResult GetSkillAdoption()
        {
            var skillAdoptionEntities = _lnRepository.GetSkillAdoption();
            return Ok(_mapper.Map<IEnumerable<SkillAdoptionDTO>>(skillAdoptionEntities));
        }
    }
}