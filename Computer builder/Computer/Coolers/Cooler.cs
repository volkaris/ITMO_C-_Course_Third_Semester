using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Proccesors;
using Itmo.ObjectOrientedProgramming.Lab2.Sizes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Coolers;

public class Cooler
{
    private readonly List<string> _supportedSockets;
    private readonly double _vendorOverestimationCoefficient = 0.7;

    internal Cooler(Size size, IEnumerable<string> supportedSocket, int tdp, string name)
    {
        Size = size;
        Tdp = tdp;
        Name = name;
        _supportedSockets = supportedSocket.ToList();
    }

    public int Tdp { get; }
    public string Name { get; }
    public IReadOnlyCollection<string> SupportedSockets => _supportedSockets;
    public Size Size { get; }

    public bool CanHandleProccesor(Processor processor)
    {
        return processor.Tdp * _vendorOverestimationCoefficient <= Tdp;
    }
}