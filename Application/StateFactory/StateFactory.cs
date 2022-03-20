namespace Application;

public class StateFactory : IStateFactory
{
    private readonly IState _startState;

    public StateFactory()
    {
        _startState = new StartState();
    }

    public IState GetQuitState()
    {
        return new QuitState();
    }

    public IState GetStartState()
    {
        return this._startState;
    }

    public IState GetState(string stateIdentifier)
    {
        throw new NotImplementedException();
    }
}