using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards.MotherboardFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Proccesors;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.Ddr;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards;

public class XmrMotherboard : Motherboard
{
    public XmrMotherboard(
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
        : base(
            socket,
            chipSet,
            ddrStandard,
            formFactor,
            amountOfPciLines,
            amountOfSataPorts,
            memorySlotsNumber,
            name,
            bios,
            gotBuiltInWifiModule)
    {
    }
}