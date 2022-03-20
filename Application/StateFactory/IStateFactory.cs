namespace Application;

public interface IStateFactory
{
    IState GetQuitState();
    IState GetStartState();
    IState GetOpponentsTurnState();
    IState GetGameStartState();
    IState GetState(string stateIdentifier);
}