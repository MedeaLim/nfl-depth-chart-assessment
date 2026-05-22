using NFLDepthChart.Api.Models;
using NFLDepthChart.Api.Services;

namespace NFLDepthChart.Tests;

public class DepthChartServiceTests
{
    [Fact]
    public void AddPlayer_ShouldAddPlayerToDepthChart()
    {
        // Arrange
        var service = new DepthChartService();

        var player = new Player
        {
            PlayerNumber = 12,
            Name = "Tom Brady"
        };

        // Act
        service.AddPlayer("QB", player, 1);

        var result = service.GetDepthChart("QB");

        // Assert
        Assert.Single(result);

        Assert.Equal("Tom Brady", result[0].Name);

        Assert.Equal(1, result[0].DepthOrder);
    }


    [Fact]
    public void AddPlayer_ShouldShiftPlayersWhenInsertedInMiddle()
    {
        // Arrange
        var service = new DepthChartService();

        service.AddPlayer("QB", new Player
        {
            PlayerNumber = 12,
            Name = "Tom Brady"
        }, 1);

        service.AddPlayer("QB", new Player
        {
            PlayerNumber = 11,
            Name = "Kyle Trask"
        }, 2);

        // Act
        service.AddPlayer("QB", new Player
        {
            PlayerNumber = 9,
            Name = "New QB"
        }, 2);

        var result = service.GetDepthChart("QB");

        // Assert
        Assert.Equal(3, result.Count);

        Assert.Equal("Tom Brady", result[0].Name);
        Assert.Equal(1, result[0].DepthOrder);

        Assert.Equal("New QB", result[1].Name);
        Assert.Equal(2, result[1].DepthOrder);

        Assert.Equal("Kyle Trask", result[2].Name);
        Assert.Equal(3, result[2].DepthOrder);
    }

    [Fact]
    public void RemovePlayer_ShouldShiftPlayersForward()
    {
        // Arrange
        var service = new DepthChartService();

        service.AddPlayer("QB", new Player
        {
            PlayerNumber = 12,
            Name = "Tom Brady"
        }, 1);

        service.AddPlayer("QB", new Player
        {
            PlayerNumber = 2,
            Name = "Blaine Gabbert"
        }, 2);

        service.AddPlayer("QB", new Player
        {
            PlayerNumber = 11,
            Name = "Kyle Trask"
        }, 3);

        // Act
        service.RemovePlayer("QB", 2);

        var result = service.GetDepthChart("QB");

        // Assert
        Assert.Equal(2, result.Count);

        Assert.Equal("Tom Brady", result[0].Name);
        Assert.Equal(1, result[0].DepthOrder);

        Assert.Equal("Kyle Trask", result[1].Name);
        Assert.Equal(2, result[1].DepthOrder);
    }

    [Fact]
    public void GetBackups_ShouldReturnPlayersBehindTargetPlayer()
    {
        // Arrange
        var service = new DepthChartService();

        service.AddPlayer("QB", new Player
        {
            PlayerNumber = 12,
            Name = "Tom Brady"
        }, 1);

        service.AddPlayer("QB", new Player
        {
            PlayerNumber = 2,
            Name = "Blaine Gabbert"
        }, 2);

        service.AddPlayer("QB", new Player
        {
            PlayerNumber = 11,
            Name = "Kyle Trask"
        }, 3);

        // Act
        var backups = service.GetBackups("QB", 12);

        // Assert
        Assert.Equal(2, backups.Count);

        Assert.Equal("Blaine Gabbert", backups[0].Name);

        Assert.Equal("Kyle Trask", backups[1].Name);
    }

    [Fact]
    public void GetDepthChart_ShouldReturnEmptyList_WhenPositionDoesNotExist()
    {
        // Arrange
        var service = new DepthChartService();

        // Act
        var result = service.GetDepthChart("WR");

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void RemovePlayer_ShouldDoNothing_WhenPlayerDoesNotExist()
    {
        // Arrange
        var service = new DepthChartService();

        service.AddPlayer("QB", new Player
        {
            PlayerNumber = 12,
            Name = "Tom Brady"
        }, 1);

        // Act
        service.RemovePlayer("QB", 999);

        var result = service.GetDepthChart("QB");

        // Assert
        Assert.Single(result);

        Assert.Equal("Tom Brady", result[0].Name);
    }

    [Fact]
    public void DifferentPositions_ShouldMaintainSeparateDepthCharts()
    {
        // Arrange
        var service = new DepthChartService();

        service.AddPlayer("QB", new Player
        {
            PlayerNumber = 12,
            Name = "Tom Brady"
        }, 1);

        service.AddPlayer("WR", new Player
        {
            PlayerNumber = 13,
            Name = "Mike Evans"
        }, 1);

        // Act
        var qbPlayers = service.GetDepthChart("QB");

        var wrPlayers = service.GetDepthChart("WR");

        // Assert
        Assert.Single(qbPlayers);
        Assert.Single(wrPlayers);

        Assert.Equal("Tom Brady", qbPlayers[0].Name);

        Assert.Equal("Mike Evans", wrPlayers[0].Name);
    }
}