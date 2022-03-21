using Application.GameInformation;
using Application.StateFactory;
using Application.States;

namespace Application.Transitions;

public class
    SimpleRockPaperScissorTransition : SimpleTransition<IRockPaperScissorGameInformation, IRockPaperScissorStateFactory>
{
    public SimpleRockPaperScissorTransition(Func<string, IRockPaperScissorGameInformation, bool> matchFunc,
        IState<IRockPaperScissorGameInformation> targetState) : base(matchFunc, targetState,
        RockPaperScissorStateFactory.GetInstance())
    {
    }

    public SimpleRockPaperScissorTransition(Func<string, IRockPaperScissorGameInformation, bool> matchFunc,
        IState<IRockPaperScissorGameInformation> targetState, string output) : base(matchFunc, targetState, output,
        RockPaperScissorStateFactory.GetInstance())
    {
    }

    public SimpleRockPaperScissorTransition(Func<string, IRockPaperScissorGameInformation, bool> matchFunc,
        IState<IRockPaperScissorGameInformation> targetState,
        Func<string, IRockPaperScissorGameInformation, IRockPaperScissorGameInformation> executeFunc)
        : base(matchFunc, targetState, executeFunc, RockPaperScissorStateFactory.GetInstance())
    {
    }

    public SimpleRockPaperScissorTransition(Func<string, IRockPaperScissorGameInformation, bool> matchFunc,
        IState<IRockPaperScissorGameInformation> targetState,
        Func<string, IRockPaperScissorGameInformation, IRockPaperScissorGameInformation> executeFunc, string output) :
        base(matchFunc, targetState, executeFunc, output, RockPaperScissorStateFactory.GetInstance())
    {
    }
}