using Itmo.ObjectOrientedProgramming.Lab2.BluetoothModule;
using Itmo.ObjectOrientedProgramming.Lab2.PciVersions;

namespace Itmo.ObjectOrientedProgramming.Lab2.WifiAdapter;

public class WiFiAdapter
{
    public WiFiAdapter(
        WifiStandart wifiStandart,
        IBluetoothModule bluetoothModule,
        IPci pciVersion,
        int consumableEnergy)
    {
        WifiStandart = wifiStandart;
        BluetoothModule = bluetoothModule;
        PciVersion = pciVersion;
        ConsumableEnergy = consumableEnergy;
    }

    public WifiStandart WifiStandart { get; }
    public IBluetoothModule BluetoothModule { get; }
    public IPci PciVersion { get; }

    public int ConsumableEnergy { get; }
}