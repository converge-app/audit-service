﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Models.DataTransferObjects;
using Application.Models.Entities;
using Application.Repositories;
using Application.Utility.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class AuditController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuditRepository _auditRepository;

        public AuditController(IAuditRepository auditRepository, IMapper mapper)
        {
            _auditRepository = auditRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AuditCreationDto auditDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });

            var createAudit = _mapper.Map<Audit>(auditDto);
            try
            {
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(new MessageObj(e.Message));
            }
        }
    }
}