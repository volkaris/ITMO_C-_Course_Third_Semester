namespace Core.OutputPorts.UserStates;

public class LoggedAsAdmin : IUserState
{
    public StateTransitionResult MoveToLoggedAsUser()
    {
        return new StateTransitionResult.UnsuccessTransition();
    }

    public StateTransitionResult MoveToLoggedAsAdmin()
    {
        return new StateTransitionResult.SuccessTransition(this);
    }

    public StateTransitionResult MoveToUnsuccessLog()
    {
        return new StateTransitionResult.UnsuccessTransition();
    }
}