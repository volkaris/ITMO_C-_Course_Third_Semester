using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.CollisionResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipStatuses;

public sealed record ShipEradicated(CollisionResult Incident) : ShipStatus;