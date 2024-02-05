namespace Core.OutputPorts.UserStates;

public abstract record StateTransitionResult()
{
    public sealed record SuccessTransition(IUserState NewState) : StateTransitionResult;

    public sealed record UnsuccessTransition() : StateTransitionResult;
}