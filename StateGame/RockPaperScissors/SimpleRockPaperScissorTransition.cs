using Application.GameInformation;
using Application.StateFactory;
using Application.Transitions;

namespace Application.RockPaperScissors;

public class
    SimpleRockPaperScissorTransition : SimpleTransition<IRockPaperScissorGameInformation, IRockPaperScissorStateFactory>
{
    public SimpleRockPaperScissorTransition() : base(RockPaperScissorStateFactory.GetInstance())
    {
    }
}