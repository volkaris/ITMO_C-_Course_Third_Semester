using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Mesage;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.CompositeAddresse;

public class GroupAdresse : IAddressee
{
    private readonly List<IAddressee> _addressees;

    public GroupAdresse(IEnumerable<IAddressee> addressees)
    {
        _addressees = addressees.ToList();
    }

    public IAddressee ReceiveMessage(Message message)
    {
        foreach (IAddressee adresse in _addressees) adresse.ReceiveMessage(message);

        return this;
    }
}