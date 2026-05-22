using System.ComponentModel.DataAnnotations;

namespace NFLDepthChart.Api.DTOs;

public class RemovePlayerRequest
{
    [Required]
    public string Position { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int PlayerNumber { get; set; }
}