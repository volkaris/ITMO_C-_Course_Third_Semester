namespace Itmo.ObjectOrientedProgramming.Lab1.ShipStatuses;

public sealed record Success(double TimeOfJourney, double TotalCost) : ShipStatus;