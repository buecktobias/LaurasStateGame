using Application.GameInformation;
using Application.StateFactory;
using Application.States;
using Application.Transitions;

namespace Application.RockPaperScissors;

public class
    SimpleRockPaperScissorTransition : SimpleTransition<IRockPaperScissorGameInformation, IRockPaperScissorStateFactory>
{
    public SimpleRockPaperScissorTransition(string output, IState<IRockPaperScissorGameInformation> targetState,
        TransitionExecuteFunc executeFunc, TransitionMatchFunc matchFunc) : base(output, targetState, executeFunc,
        matchFunc)
    {
    }
}