using Itmo.ObjectOrientedProgramming.Lab1.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab1.FlightResponses;

public class FlightResponse
{
    public FlightResponse(double time, double fuel, SegmentResults res)
    {
        TimeResult = time;
        FuelResult = fuel;
        SegmentResult = res;
    }

    public double TimeResult { get; set; }
    public double FuelResult { get; set; }
    public SegmentResults SegmentResult { get; set; }
}