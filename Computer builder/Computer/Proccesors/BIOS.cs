using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Proccesors;

public class Bios
{
    private List<Processor> _supportedProcessors;

    internal Bios(string type, int version, IEnumerable<Processor> supportedProcessors)
    {
        Type = type;
        Version = version;
        _supportedProcessors = supportedProcessors.ToList();
    }

    internal Bios(Bios bios)
    {
        Type = bios.Type;
        Version = bios.Version;
        _supportedProcessors = bios._supportedProcessors.ToList();
    }

    public IReadOnlyCollection<Processor> SupportedProcessors => _supportedProcessors;
    private string Type { get; set; }
    private int Version { get; set; }

    public void Upgrade(string newType, int newVersion, IEnumerable<Processor> additionalSupportedProcessors)
    {
        Type = newType;
        Version = newVersion;
        _supportedProcessors = _supportedProcessors.Concat(additionalSupportedProcessors).ToList();
    }

    public bool ValidateProccesorAvailability(Processor? currentProcessor)
    {
        return _supportedProcessors.Any(processor =>
            processor.Equals(currentProcessor));
    }
}