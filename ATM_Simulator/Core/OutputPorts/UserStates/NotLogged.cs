namespace Core.OutputPorts.UserStates;

public class NotLogged : IUserState
{
    public StateTransitionResult MoveToLoggedAsUser()
    {
        return new StateTransitionResult.SuccessTransition(new LoggedAsUser());
    }

    public StateTransitionResult MoveToLoggedAsAdmin()
    {
        return new StateTransitionResult.SuccessTransition(new LoggedAsAdmin());
    }

    public StateTransitionResult MoveToUnsuccessLog()
    {
        return new StateTransitionResult.SuccessTransition(this);
    }
}