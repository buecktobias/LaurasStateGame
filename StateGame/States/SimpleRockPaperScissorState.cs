using Application.GameInformation;
using Application.TransitionFactory;
using Application.Transitions;

namespace Application.States;

public class
    SimpleRockPaperScissorState : SimpleState<IRockPaperScissorGameInformation, IRockPaperScissorTransitionFactory>
{
    public SimpleRockPaperScissorState(string introOutput) : base(introOutput,
        TransitionFactory.RockPaperScissorTransitionFactory.GetInstance())
    {
    }

    public SimpleRockPaperScissorState(string introOutput,
        IList<ITransition<IRockPaperScissorGameInformation>> newTransitions) : base(introOutput, newTransitions,
        TransitionFactory.RockPaperScissorTransitionFactory.GetInstance())
    {
    }

    public SimpleRockPaperScissorState(string introOutput,
        IList<ITransition<IRockPaperScissorGameInformation>> newTransitions, string outroOutput, bool endState) : base(
        introOutput, newTransitions, outroOutput, endState,
        TransitionFactory.RockPaperScissorTransitionFactory.GetInstance())
    {
    }

    public SimpleRockPaperScissorState(string introOutput,
        IList<ITransition<IRockPaperScissorGameInformation>> transitions, string outroOutput, bool isEndState,
        Func<IRockPaperScissorGameInformation, IRockPaperScissorGameInformation> executeFunc) : base(introOutput,
        transitions, outroOutput, isEndState, executeFunc,
        TransitionFactory.RockPaperScissorTransitionFactory.GetInstance())
    {
    }
}