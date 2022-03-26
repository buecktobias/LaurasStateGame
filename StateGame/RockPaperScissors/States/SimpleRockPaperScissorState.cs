using Application.GameInformation;
using Application.States;
using Application.TransitionFactory;

namespace Application.RockPaperScissors.States;

internal class SimpleRockPaperScissorState : AbstractState<IRockPaperScissorGameInformation, IRockPaperScissorTransitionFactory>
{
    internal SimpleRockPaperScissorState() : base(RockPaperScissors.RockPaperScissorTransitionFactory.GetInstance())
    {
    }

    public override bool NeedsUserInput()
    {
        return false;
    }
}