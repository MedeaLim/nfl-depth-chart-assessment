using System.ComponentModel.DataAnnotations;

namespace NFLDepthChart.Api.DTOs;

public class AddPlayerRequest
{
    [Required]
    public string Position { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int PlayerNumber { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int DepthOrder { get; set; }
}