namespace Core.OutputPorts.UserStates;

public interface IUserState
{
    StateTransitionResult MoveToLoggedAsUser();
    StateTransitionResult MoveToLoggedAsAdmin();

    StateTransitionResult MoveToUnsuccessLog();
}