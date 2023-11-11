using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Enums;
using Itmo.ObjectOrientedProgramming.Lab1.Responses;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.UnitTests;

public class WhaleInFogTest
{
    [Fact]

    public void VaclasAndWhale()
    {
        var ship = new Vaclas();

        var obstacles = new List<int> { 0, 0, 1, 0 };
        var env = new NitrinFog(obstacles);
        var segment = new RouteSegment(env, 500);
        var adventure = new Adventure(ship, new List<RouteSegment> { segment });

        FlightResponse response = adventure.StartAdventure();

        Assert.Equal(SegmentResults.ShipIsDestroyed, response.SegmentResult);
    }

    [Fact]

    public void AugurAndWhale()
    {
        var ship = new Augur();

        var obstacles = new List<int> { 0, 0, 1, 0 };
        var env = new NitrinFog(obstacles);
        var segment = new RouteSegment(env, 500);
        var adventure = new Adventure(ship, new List<RouteSegment> { segment });

        FlightResponse response = adventure.StartAdventure();

        Assert.Equal(SegmentResults.Success, response.SegmentResult);
    }

    [Fact]

    public void MeredianAndWhale()
    {
        var ship = new Meredian();

        var obstacles = new List<int> { 0, 0, 1, 0 };
        var env = new NitrinFog(obstacles);
        var segment = new RouteSegment(env, 500);
        var adventure = new Adventure(ship, new List<RouteSegment> { segment });

        FlightResponse response = adventure.StartAdventure();

        Assert.Equal(SegmentResults.Success, response.SegmentResult);
    }
}