using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Enums;
using Itmo.ObjectOrientedProgramming.Lab1.Responses;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.UnitTests;

public class AugurCrashTest
{
    [Fact]

    public void ExtraTest()
    {
        var ship = new Augur();
        ship.PhotonicDeflector = new PhotonicDeflector();

        var obstacle1 = new List<int> { 0, 0, 1, 0 };
        var env1 = new NitrinFog(obstacle1);
        var segment1 = new RouteSegment(env1, 500);

        var obstacle2 = new List<int> { 0, 0, 0, 2 };
        var env2 = new DenseFog(obstacle2);
        var segment2 = new RouteSegment(env2, 500);

        var adventure = new Adventure(ship, new List<RouteSegment> { segment1, segment2 });

        FlightResponse response = adventure.StartAdventure();

        Assert.Equal(SegmentResults.Success, response.SegmentResult);
    }
}