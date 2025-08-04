using Microsoft.AspNetCore.Mvc;
using MicroX.Application.Interfaces;
using MicroX.Contracts.DTOs;
using System.Collections.Generic;

namespace MicroX.API.Controllers;

/// <summary>
/// Provides endpoints to retrieve and add service information entries.
/// </summary>
[ApiController]
[Route("api/v1/serviceinfo")]
public class ServiceInfoController : ControllerBase
{
    private readonly IServiceInfoService _service;

    public ServiceInfoController(IServiceInfoService service)
    {
        _service = service;
    }

    /// <summary>
    /// Retrieves all registered service info records.
    /// </summary>
    /// <returns>A list of service information records.</returns>
    /// <response code="200">Returns the list of service info DTOs.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ServiceInfoDto>), 200)]
    public ActionResult<IEnumerable<ServiceInfoDto>> GetAll()
    {
        return Ok(_service.GetAll());
    }

    /// <summary>
    /// Adds a new service info record.
    /// </summary>
    /// <param name="dto">The service info to add.</param>
    /// <returns>A 201 response if created successfully.</returns>
    /// <response code="201">Service info was successfully added.</response>
    /// <response code="400">If the input is invalid.</response>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public IActionResult Add(ServiceInfoDto dto)
    {
        _service.Add(dto);
        return CreatedAtAction(nameof(GetAll), null);
    }
}
