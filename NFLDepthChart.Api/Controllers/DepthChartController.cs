using NFLDepthChart.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using NFLDepthChart.Api.Models;
using NFLDepthChart.Api.Services;

namespace NFLDepthChart.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepthChartController : ControllerBase
{
    private readonly IDepthChartService _depthChartService;

    public DepthChartController(IDepthChartService depthChartService)
    {
        _depthChartService = depthChartService;
    }

    [HttpGet("{position}")]
    public IActionResult GetDepthChart(string position)
    {
        var result = _depthChartService.GetDepthChart(position);

        return Ok(result);
    }

    [HttpPost("add")]
    public IActionResult AddPlayer(AddPlayerRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var player = new Player
        {
            PlayerNumber = request.PlayerNumber,
            Name = request.Name
        };

        _depthChartService.AddPlayer(
            request.Position,
            player,
            request.DepthOrder
        );

        return Ok();
    }

    [HttpGet("{position}/backups/{playerNumber}")]
    public IActionResult GetBackups(string position, int playerNumber)
    {
        var backups = _depthChartService.GetBackups(position, playerNumber);

        return Ok(backups);
    }

    [HttpDelete("remove")]
    public IActionResult RemovePlayer(RemovePlayerRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _depthChartService.RemovePlayer(
            request.Position,
            request.PlayerNumber
        );

        return Ok();
    }
}