namespace Itmo.ObjectOrientedProgramming.Lab2.ComponenetsConnectionResults;

public abstract record ComponenetsConnectionsResult
{
    private ComponenetsConnectionsResult() { }

    public record FatalProblem(string FatalProblemReason) : ComponenetsConnectionsResult;

    public record ComponenetsConnectedSuccessfully : ComponenetsConnectionsResult;

    public sealed record DisclaimerOfWarranty(string WarrantyDenialReason) : ComponenetsConnectedSuccessfully;

    public sealed record BuildingRemarks(string Remark) : ComponenetsConnectedSuccessfully;
}