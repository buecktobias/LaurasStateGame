using Application.GameInformation;
using Application.TransitionFactory;

namespace Application.States;

public class SimpleRockPaperScissorBuilder : SimpleStateBuilder<IRockPaperScissorGameInformation, IRockPaperScissorTransitionFactory>
{
    public SimpleRockPaperScissorBuilder() : base(RockPaperScissorTransitionFactory.GetInstance())
    {
    }
}