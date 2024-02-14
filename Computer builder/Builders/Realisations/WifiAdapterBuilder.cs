using System;
using Itmo.ObjectOrientedProgramming.Lab2.BluetoothModule;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.PciVersions;
using Itmo.ObjectOrientedProgramming.Lab2.WifiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Realisations;

public class WifiAdapterBuilder : IWifiAdapterBuilder
{
    private WifiStandart? _wifiStandart;
    private IBluetoothModule? _bluetoothModule;
    private IPci? _pciVersion;
    private int? _consumableEnergy;

    public IWifiAdapterBuilder WithWifiStandart(WifiStandart wifiStandart)
    {
        _wifiStandart = wifiStandart;
        return this;
    }

    public IWifiAdapterBuilder WithBluetoothModule(IBluetoothModule bluetoothModule)
    {
        _bluetoothModule = bluetoothModule;
        return this;
    }

    public IWifiAdapterBuilder WithPciVersion(IPci pciVersion)
    {
        _pciVersion = pciVersion;
        return this;
    }

    public IWifiAdapterBuilder WithConsumableEnergy(int consumableEnergy)
    {
        _consumableEnergy = consumableEnergy;
        return this;
    }

    public WiFiAdapter Build()
    {
        return new WiFiAdapter(
            _wifiStandart ?? throw new ArgumentNullException(nameof(_wifiStandart)),
            _bluetoothModule ?? throw new ArgumentNullException(nameof(_bluetoothModule)),
            _pciVersion ?? throw new ArgumentNullException(nameof(_pciVersion)),
            _consumableEnergy ?? throw new ArgumentNullException(nameof(_consumableEnergy)));
    }
}