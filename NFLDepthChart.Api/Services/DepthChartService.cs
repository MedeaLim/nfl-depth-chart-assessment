using NFLDepthChart.Api.Models;

namespace NFLDepthChart.Api.Services;

public class DepthChartService : IDepthChartService
{
    private readonly Dictionary<string, List<Player>> _depthCharts = new();

    public void AddPlayer(string position, Player player, int depth)
    {
        if (!_depthCharts.ContainsKey(position))
        {
            _depthCharts[position] = new List<Player>();
        }

        var players = _depthCharts[position];

        if (players.Any(p => p.PlayerNumber == player.PlayerNumber))
        {
            return;
        }

        foreach (var existingPlayer in players)
        {
            if (existingPlayer.DepthOrder >= depth)
            {
                existingPlayer.DepthOrder++;
            }
        }

        player.Position = position;
        player.DepthOrder = depth;

        players.Add(player);

        _depthCharts[position] = players
            .OrderBy(p => p.DepthOrder)
            .ToList();
    }

    public void RemovePlayer(string position, int playerNumber)
    {
        if (!_depthCharts.ContainsKey(position))
        {
            return;
        }

        var players = _depthCharts[position];

        var playerToRemove = players
            .FirstOrDefault(p => p.PlayerNumber == playerNumber);

        if (playerToRemove == null)
        {
            return;
        }

        int removedDepth = playerToRemove.DepthOrder;

        players.Remove(playerToRemove);

        foreach (var player in players)
        {
            if (player.DepthOrder > removedDepth)
            {
                player.DepthOrder--;
            }
        }

        _depthCharts[position] = players
            .OrderBy(p => p.DepthOrder)
            .ToList();
    }

    public List<Player> GetBackups(string position, int playerNumber)
    {
        if (!_depthCharts.ContainsKey(position))
        {
            return new List<Player>();
        }

        var players = _depthCharts[position]
            .OrderBy(p => p.DepthOrder)
            .ToList();

        var player = players
            .FirstOrDefault(p => p.PlayerNumber == playerNumber);

        if (player == null)
        {
            return new List<Player>();
        }

        return players
            .Where(p => p.DepthOrder > player.DepthOrder)
            .ToList();
    }

    public List<Player> GetDepthChart(string position)
    {
        if (!_depthCharts.ContainsKey(position))
        {
            return new List<Player>();
        }

        return _depthCharts[position]
            .OrderBy(p => p.DepthOrder)
            .ToList();
    }
}