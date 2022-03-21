using Application.GameInformation;
using Application.StateFactory;
using Application.Transitions;

namespace Application.RockPaperScissors;

public class TransitionBuilder : SimpleTransitionBuilder<IRockPaperScissorGameInformation, IRockPaperScissorStateFactory>
{
    public TransitionBuilder() : base(RockPaperScissorStateFactory.GetInstance())
    {
    }
}