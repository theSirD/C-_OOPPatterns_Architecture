using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class AdventureService
{
    private readonly BaseShip _ship;

    public AdventureService(BaseShip ship)
    {
        _ship = ship;
    }

    public void TakeDamageFromSegment(IList<int>? obstacles)
    {
        if (obstacles is null) return;

        for (int i = 0; i < obstacles.Count; i++)
        {
            _ship.TakeDamage(i, obstacles[i]);
        }
    }
}