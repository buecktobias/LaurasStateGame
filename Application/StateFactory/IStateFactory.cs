namespace Application;

public interface IStateFactory
{
    IState GetQuitState();
    IState GetStartState();
    IState GetState(string stateIdentifier);
}