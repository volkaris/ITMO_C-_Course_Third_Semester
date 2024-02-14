using Itmo.ObjectOrientedProgramming.Lab2.BluetoothModule;
using Itmo.ObjectOrientedProgramming.Lab2.PciVersions;
using Itmo.ObjectOrientedProgramming.Lab2.WifiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Interfaces;

public interface IWifiAdapterBuilder
{
    public IWifiAdapterBuilder WithWifiStandart(WifiStandart wifiStandart);
    public IWifiAdapterBuilder WithBluetoothModule(IBluetoothModule bluetoothModule);
    public IWifiAdapterBuilder WithPciVersion(IPci pciVersion);
    public IWifiAdapterBuilder WithConsumableEnergy(int consumableEnergy);

    public WiFiAdapter Build();
}