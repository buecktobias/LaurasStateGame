namespace Application.StateFactory;

public interface IRockPaperScissorStateFactory
{
    IState GetQuitState();
    IState GetOpponentsTurnState();
    IState GetGameStartState();
}