using Application.Exceptions;
using Application.GameInformation;
using Application.StateFactory;
using Application.States;

namespace Application.Transitions;

public delegate bool TransitionMatchFunc(string inputText, IGameInformation gameInformation);

public delegate IGameInformation TransitionExecuteFunc(string inputText, IGameInformation gameInformation);

public class SimpleTransition<TGameInformation, TStateFactory> : AbstractTransition<TGameInformation, TStateFactory>
    where TGameInformation : IGameInformation
    where TStateFactory : IStateFactory
{
    public SimpleTransition(string output, IState<TGameInformation> targetState,
        TransitionExecuteFunc executeFunc, TransitionMatchFunc matchFunc)
    {
        Output = output;
        TargetState = targetState;
        ExecuteFunc = executeFunc;
        MatchFunc = matchFunc;
    }

    private TransitionMatchFunc? MatchFunc { get; }

    private TransitionExecuteFunc ExecuteFunc { get; }

    private IState<TGameInformation> TargetState { get; }

    private string Output { get; }


    public override bool Matches(string input, TGameInformation gameInformation)
    {
        return MatchFunc(input, gameInformation);
    }

    public override IState<TGameInformation> GetTargetState()
    {
        if (TargetState == null) throw new TargetStateNotSetException();
        return TargetState;
    }

    public override TGameInformation Execute(string input, TGameInformation rockPaperScissorGameInformation)
    {
        return (TGameInformation) ExecuteFunc(input, rockPaperScissorGameInformation);
    }

    public override string GetOutput()
    {
        return Output;
    }
}