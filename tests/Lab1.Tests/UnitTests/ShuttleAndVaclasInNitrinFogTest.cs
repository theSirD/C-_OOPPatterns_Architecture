using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Enums;
using Itmo.ObjectOrientedProgramming.Lab1.Responses;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.UnitTests;

public class ShuttleAndVaclasInNitrinFogTest
{
    [Fact]

    public void ShuttleVsVaclasInNitrinFog()
    {
        var ship1 = new Vaclas();

        var obstacles = new List<int> { 0, 0, 0, 0 };
        var env = new NitrinFog(obstacles);
        var segment = new RouteSegment(env, 500);
        var adventure1 = new Adventure(ship1, new List<RouteSegment> { segment });

        FlightResponse response1 = adventure1.StartAdventure();

        var ship2 = new PleasureShuttle();

        var adventure2 = new Adventure(ship2, new List<RouteSegment> { segment });

        FlightResponse response2 = adventure2.StartAdventure();

        Assert.True(response1.SegmentResult == SegmentResults.Success
            && response2.SegmentResult == SegmentResults.ShipIsLost);
    }
}