using Application.GameInformation;
using Application.StateFactory;
using Application.States;

namespace Application.Transitions;

public class SimpleTransition<TGameInformation, TStateFactory> : AbstractTransition<TGameInformation, TStateFactory>
where TGameInformation : IGameInformation
where TStateFactory : IStateFactory
{
    private Func<string, TGameInformation, bool> MatchFunc { get; }
    private Func<string, TGameInformation, TGameInformation> ExecuteFunc { get; }
    private IState<TGameInformation> State { get; }
    private string Output { get; }

    public SimpleTransition(Func<string, TGameInformation, bool> matchFunc,
        IState<TGameInformation> targetState,
        TStateFactory stateFactory) :
        this(matchFunc, targetState, ((s, information) => information), "", stateFactory)
    {
    }

    public SimpleTransition(Func<string, TGameInformation, bool> matchFunc,
        IState<TGameInformation> targetState,
        string output, TStateFactory stateFactory) :
        this(matchFunc, targetState, ((s, information) => information), output, stateFactory)
    {
    }

    public SimpleTransition(
        Func<string, TGameInformation, bool> matchFunc,
        IState<TGameInformation> targetState,
        Func<string, TGameInformation, TGameInformation> executeFunc,
        TStateFactory stateFactory) :
        this(matchFunc, targetState, executeFunc, "",stateFactory)
    {
    }

    public SimpleTransition(
        Func<string, TGameInformation, bool> matchFunc,
        IState<TGameInformation> targetState,
        Func<string, TGameInformation, TGameInformation> executeFunc,
        string output,
        TStateFactory stateFactory) : base(stateFactory)
    {
        MatchFunc = matchFunc;
        State = targetState;
        ExecuteFunc = executeFunc;
        Output = output;
    }

    public override bool Matches(string input, TGameInformation gameInformation)
    {
        return MatchFunc(input, gameInformation);
    }

    public override IState<TGameInformation> GetTargetState()
    {
        return State;
    }

    public override TGameInformation Execute(string input, TGameInformation rockPaperScissorGameInformation)
    {
        return ExecuteFunc(input, rockPaperScissorGameInformation);
    }

    public override string GetOutput()
    {
        return Output;
    }
}