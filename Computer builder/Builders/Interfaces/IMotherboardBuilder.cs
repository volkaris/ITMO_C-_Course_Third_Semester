using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards.MotherboardFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Proccesors;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.RandomAccessMemories.Ddr;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Interfaces;

public interface IMotherboardBuilder
{
    IMotherboardBuilder PciLinesAmount(int amountOfPciLines);
    IMotherboardBuilder SataPortAmount(int amountOfSataPort);
    IMotherboardBuilder WithMemorySlotsNumber(int memorySlotsNumber);

    IMotherboardBuilder WithSocket(Socket socket);
    IMotherboardBuilder WithName(string name);

    IMotherboardBuilder WithBios(Bios bios);
    IMotherboardBuilder WithChipSet(ChipSet chipSet);
    IMotherboardBuilder WithDdrStandard(IDdr ddr);
    IMotherboardBuilder WithMotherboardFormFactor(IMotherboardFormFactor formFactor);
    Motherboard Build();
}