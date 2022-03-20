namespace Application.StateFactory;

public interface IStateFactory
{
    IState GetQuitState();
    IState GetOpponentsTurnState();
    IState GetGameStartState();
}