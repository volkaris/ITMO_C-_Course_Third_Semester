using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards;

public class ChipSet
{
    private readonly List<int> _availableFrequencies;

    public ChipSet(bool xmrSupport, IEnumerable<int> availableFrequencies)
    {
        XmrSupport = xmrSupport;
        _availableFrequencies = availableFrequencies.ToList();
        MaxMemoryFrequency = _availableFrequencies.Max();
    }

    public int MaxMemoryFrequency { get; set; }
    public bool XmrSupport { get; }
    public IReadOnlyCollection<int> AvailableFrequencies => _availableFrequencies;
}