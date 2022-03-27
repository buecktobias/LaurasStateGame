using Application.GameInformation;
using Application.Transitions;

namespace Application.TransitionFactory;

public interface IRockPaperScissorTransitionFactory : ITransitionFactory<IRockPaperScissorGameInformation>
{
    ITransition<IRockPaperScissorGameInformation> GetGameWonTransition();
    ITransition<IRockPaperScissorGameInformation> GetGameDrawTransition();
    ITransition<IRockPaperScissorGameInformation> GetGameLostTransition();
    ITransition<IRockPaperScissorGameInformation> GetGamePlayTransition();
}