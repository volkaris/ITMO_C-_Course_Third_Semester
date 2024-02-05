using Core.OutputPorts.UserStates;

namespace Core.OutputPorts;

public class User
{
    public User(string id, string password, IUserState state, uint money = 0)
    {
        Id = id;
        Password = password;
        State = state;
        Money = money;
    }

    public string Id { get; }
    public string Password { get; }

    public uint Money { get; private set; }
    public IUserState State { get; private set; }

    public void LoggedAsUser()
    {
        if (State.MoveToLoggedAsUser() is StateTransitionResult.SuccessTransition result) State = result.NewState;
    }

    public void LoggedAsAdmin()
    {
        if (State.MoveToLoggedAsAdmin() is StateTransitionResult.SuccessTransition result) State = result.NewState;
    }

    public void UnsuccessfulLog()
    {
        if (State.MoveToUnsuccessLog() is StateTransitionResult.SuccessTransition result) State = result.NewState;
    }
}