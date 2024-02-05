namespace Core.OutputPorts.UserStates;

public class LoggedAsUser : IUserState
{
    public StateTransitionResult MoveToLoggedAsUser()
    {
        return new StateTransitionResult.SuccessTransition(this);
    }

    public StateTransitionResult MoveToLoggedAsAdmin()
    {
        return new StateTransitionResult.UnsuccessTransition();
    }

    public StateTransitionResult MoveToUnsuccessLog()
    {
        return new StateTransitionResult.UnsuccessTransition();
    }
}