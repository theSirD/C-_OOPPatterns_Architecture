using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Enums;
using Itmo.ObjectOrientedProgramming.Lab1.Responses;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSegments.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.UnitTests;

public class FlashAndVaclasTest
{
    [Fact]

    public void VaclasWithoutPhotonicDeflectors()
    {
        var ship = new Vaclas();

        var obstacles = new List<int> { 0, 0, 0, 1 };
        var env = new DenseFog(obstacles);
        var segment = new RouteSegment(env, 1000);
        var adventure = new Adventure(ship, new List<RouteSegment> { segment });

        FlightResponse response = adventure.StartAdventure();

        Assert.Equal(SegmentResults.CrewIsDead, response.SegmentResult);
    }

    [Fact]

    public void VaclasWithPhotonicDeflectors()
    {
        var ship = new Vaclas();
        ship.PhotonicDeflector = new PhotonicDeflector();

        var obstacles = new List<int> { 0, 0, 0, 1 };
        var env = new DenseFog(obstacles);
        var segment = new RouteSegment(env, 1000);
        var adventure = new Adventure(ship, new List<RouteSegment> { segment });

        FlightResponse response = adventure.StartAdventure();

        Assert.Equal(SegmentResults.Success, response.SegmentResult);
    }
}