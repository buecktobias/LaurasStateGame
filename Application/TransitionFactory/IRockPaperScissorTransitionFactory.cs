using Application.Transitions;

namespace Application.TransitionFactory;

public interface IRockPaperScissorTransitionFactory
{
    ITransition GetNoMatchTransition();
    ITransition GetGameWonTransition();
    ITransition GetGameDrawTransition();
    ITransition GetGameLostTransition();
    ITransition GetGamePlayTransition();
}