using Application.GameInformation;
using Application.States;
using Application.TransitionFactory;

namespace Application.RockPaperScissors.States;

internal class SimpleRockPaperScissorState : SimpleState<IRockPaperScissorGameInformation, IRockPaperScissorTransitionFactory>
{
    internal SimpleRockPaperScissorState() : base(RockPaperScissors.RockPaperScissorTransitionFactory.GetInstance())
    {
    }
}