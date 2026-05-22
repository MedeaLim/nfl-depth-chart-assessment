using NFLDepthChart.Api.Models;

namespace NFLDepthChart.Api.Services;

public interface IDepthChartService
{
    void AddPlayer(string position, Player player, int depth);

    void RemovePlayer(string position, int playerNumber);

    List<Player> GetBackups(string position, int playerNumber);

    List<Player> GetDepthChart(string position);
}