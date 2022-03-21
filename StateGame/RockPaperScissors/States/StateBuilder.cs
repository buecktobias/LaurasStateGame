using Application.GameInformation;
using Application.States;
using Application.TransitionFactory;

namespace Application.RockPaperScissors.States;

public class SimpleRockPaperScissorBuilder : SimpleStateBuilder<IRockPaperScissorGameInformation, IRockPaperScissorTransitionFactory>
{
    public SimpleRockPaperScissorBuilder() : base(RockPaperScissorTransitionFactory.GetInstance())
    {
    }
}