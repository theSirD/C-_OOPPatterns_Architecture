using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Enums;
using Itmo.ObjectOrientedProgramming.Lab1.Responses;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.UnitTests;

public class ShuttleAndAugurFogTest
{
    [Fact]

    public void ShuttleInFog()
    {
        var ship = new PleasureShuttle();

        var obstacles = new List<int> { 0, 0, 0, 0 };
        var env = new DenseFog(obstacles);
        var segment = new RouteSegment(env, 1000);
        var adventure = new Adventure(ship, new List<RouteSegment> { segment });

        FlightResponse response = adventure.StartAdventure();

        Assert.Equal(SegmentResults.ShipIsLost, response.SegmentResult);
    }

    [Fact]

    public void AugurInFog()
    {
        var ship = new Augur();

        var obstacles = new List<int> { 0, 0, 0, 0 };
        var env = new DenseFog(obstacles);
        var segment = new RouteSegment(env, 1000);
        var adventure = new Adventure(ship, new List<RouteSegment> { segment });

        FlightResponse response = adventure.StartAdventure();

        Assert.Equal(SegmentResults.ShipIsLost, response.SegmentResult);
    }
}