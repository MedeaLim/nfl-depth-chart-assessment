namespace NFLDepthChart.Api.Models;

public class Player
{
    public int PlayerNumber { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Position { get; set; } = string.Empty;

    public int DepthOrder { get; set; }
}
