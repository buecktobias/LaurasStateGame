using Application.GameInformation;
using Application.States;

namespace Application.StateFactory;

public interface IRockPaperScissorStateFactory : IStateFactory
{
    IState<IRockPaperScissorGameInformation> GetQuitState();
    IState<IRockPaperScissorGameInformation> GetOpponentsTurnState();
    IState<IRockPaperScissorGameInformation> GetGameStartState();
}