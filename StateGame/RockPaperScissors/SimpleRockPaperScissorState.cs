using Application.GameInformation;
using Application.TransitionFactory;
using Application.Transitions;

namespace Application.States;

public class SimpleRockPaperScissorState : SimpleState<IRockPaperScissorGameInformation, IRockPaperScissorTransitionFactory>
{
    internal SimpleRockPaperScissorState(IRockPaperScissorTransitionFactory transitionFactory) : base(transitionFactory)
    {
    }
}