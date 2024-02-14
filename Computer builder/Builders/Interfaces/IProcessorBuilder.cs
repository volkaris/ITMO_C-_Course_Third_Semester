using Itmo.ObjectOrientedProgramming.Lab2.Computer.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Proccesors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Interfaces;

public interface IProcessorBuilder
{
    IProcessorBuilder WithCoresAmount(int coresAmount);
    IProcessorBuilder WithCoresFrequency(double coresFrequency);

    IProcessorBuilder WithSocket(Socket socket);
    IProcessorBuilder WithBuiltInVideoCore(bool builtInVideoCore);

    IProcessorBuilder WithRamMaximumFrequency(int ramMaximumFrequency);
    IProcessorBuilder WithTdp(int tdp);

    IProcessorBuilder WithPowerConsumption(int powerConsumption);

    IProcessorBuilder WithName(string name);

    Processor Build();
}