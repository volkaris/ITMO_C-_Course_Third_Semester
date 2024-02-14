using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Coolers;
using Itmo.ObjectOrientedProgramming.Lab2.Sizes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Interfaces;

public interface ICoolerBuilder
{
    ICoolerBuilder WithName(string name);
    ICoolerBuilder WithTdp(int tdp);
    ICoolerBuilder WithSupportedSockets(IEnumerable<string> supportedSocket);
    ICoolerBuilder WithSize(Size size);

    Cooler Build();
}