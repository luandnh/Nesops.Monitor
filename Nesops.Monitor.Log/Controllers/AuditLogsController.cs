﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NesopsService.Data;
using NesopsService.Data.Entities;
using NesopsService.Domain.Models;
using NesopsService.EntityControllerBase;
using NesopsService.Service.EntityServices;
using NesopsService.Service.Models.RequestModels;
using NesopsService.Service.Models.ResponseModels;

namespace Nesops.Monitor.Log.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogsController : EntityControllerBase<NesopsMonitorContext, AuditLogs, AuditLogsReadModel, AuditLogsCreateModel, AuditLogsUpdateModel, AuditLogRequestModel, AuditLogService>
    {
        public AuditLogsController(NesopsMonitorContext dataContext, IMapper mapper, AuditLogService service) : base(dataContext, mapper, service)
        {
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetResponseModel<AuditLogsReadModel, AuditLogRequestModel>>> Get(Guid id, [FromQuery] AuditLogRequestModel requestModel, CancellationToken cancellationToken)
        {
            var readModel = await ReadModel(id, requestModel, cancellationToken);
            if (readModel == null)
                return NotFound(new BaseResponseModel<object> { message = "Not found", code = 404 });
            return Ok(readModel);
        }
        [HttpGet]
        public async Task<ActionResult<GetResponseModel<AuditLogsReadModel, AuditLogRequestModel>>> List([FromQuery] AuditLogRequestModel requestModel, CancellationToken cancellationToken)
        {
            var readModels = await ListModel(requestModel, cancellationToken);
            return Ok(readModels);
        }
        [HttpPost]
        [Authorize(Roles = "Web Application")]
        public async Task<ActionResult<AuditLogsReadModel>> Create([FromBody]AuditLogsCreateModel createModel, CancellationToken cancellationToken)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            createModel.SysId = Guid.Parse(userId);
            var readModel = await CreateModel(createModel, cancellationToken);
            return CreatedAtAction(nameof(Get), new { id = readModel.Id }, readModel);
        }
    }
}