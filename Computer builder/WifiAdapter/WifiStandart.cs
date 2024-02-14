using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.WifiAdapter;

public record WifiStandart
{
    private readonly int _standart;

    public WifiStandart(int standart)
    {
        if (standart < 0)
            throw new ArgumentException("Value cannot be negative", nameof(standart));
        _standart = standart;
    }
}