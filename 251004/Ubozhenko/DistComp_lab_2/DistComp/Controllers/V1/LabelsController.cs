﻿using DistComp.DTO.RequestDTO;
using DistComp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DistComp.Controllers.V1;

[ApiController]
[Route("api/v1.0/[controller]")]
public class LabelsController : ControllerBase
{
    private readonly ILabelService _labelService;

    public LabelsController(ILabelService labelService)
    {
        _labelService = labelService;
    }

    [HttpGet]
    public async Task<IActionResult> GetLabels()
    {
        var labels = await _labelService.GetLabelsAsync();
        return Ok(labels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLabelById(long id)
    {
        var label = await _labelService.GetLabelByIdAsync(id);
        return Ok(label);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLabel([FromBody] LabelResponseDTO label)
    {
        var createdLabel = await _labelService.CreateLabelsync(label);
        return CreatedAtAction(nameof(CreateLabel), new { id = createdLabel.Id }, createdLabel);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateLabel([FromBody] LabelResponseDTO label)
    {
        var updatedLabel = await _labelService.UpdateLabelAsync(label);
        return Ok(updatedLabel);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLabel(long id)
    {
        await _labelService.DeleteLabelAsync(id);
        return NoContent();
    }
}