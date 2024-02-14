using Itmo.ObjectOrientedProgramming.Lab2.Computer.InformationKeepers;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.InformationKeepers.ConnectionVariant;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards.MotherboardFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Proccesors;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.Ddr;
using Itmo.ObjectOrientedProgramming.Lab2.WifiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards;

public class Motherboard
{
    internal Motherboard(
        Socket socket,
        ChipSet chipSet,
        IDdr ddrStandard,
        IMotherboardFormFactor formFactor,
        int amountOfPciLines,
        int amountOfSataPorts,
        int memorySlotsNumber,
        string name,
        Bios bios,
        bool gotBuiltInWifiModule)
    {
        Socket = socket;
        ChipSet = chipSet;
        DdrStandard = ddrStandard;
        FormFactor = formFactor;
        MemorySlotsNumber = memorySlotsNumber;
        Name = name;
        AmountOfPciLines = amountOfPciLines;
        AmountOfSataPorts = amountOfSataPorts;
        Bios = bios;
        GotBuiltInWifiModule = gotBuiltInWifiModule;
    }

    public string Name { get; }
    public int AmountOfPciLines { get; private set; }

    public bool GotBuiltInWifiModule { get; }

    public Socket Socket { get; }

    public Bios Bios { get; }
    public int AmountOfSataPorts { get; private set; }
    public ChipSet ChipSet { get; }
    public IDdr DdrStandard { get; }
    public int MemorySlotsNumber { get; }
    public IMotherboardFormFactor FormFactor { get; }

    public bool ValidateWifiCompatibility(WiFiAdapter? wifiAdapter)
    {
        return !(GotBuiltInWifiModule && wifiAdapter is not null);
    }

    public bool IsProcessorCompatible(Processor processor)
    {
        return Socket.CompatibleWith(processor.Socket);
    }

    public bool ValidateXmrTechonologyAvailability(RandomAccessMemory memory)
    {
        return (ChipSet.XmrSupport && memory is RamWithXmp) || memory is not RamWithXmp;
    }

    public bool DoesNotHaveAnySpaceForMemoryKeepers()
    {
        return AmountOfPciLines < 0 || AmountOfSataPorts < 0;
    }

    public void Connect(IInformationKeeper informationKeeper)
    {
        switch (informationKeeper.ConnectionVariant)
        {
            case SataConnection:
                --AmountOfSataPorts;
                break;
            case PciConnection:
                --AmountOfPciLines;
                break;
        }
    }
}