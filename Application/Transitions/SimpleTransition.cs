namespace Application.Transitions;

public class SimpleTransition : AbstractTransition
{
    private Func<string, IGameInformation, bool> MatchFunc { get; }
    private Func<string, IGameInformation, IGameInformation> ExecuteFunc { get; }
    private IState State { get; }
    private string Output { get; }

    public SimpleTransition(Func<string, IGameInformation, bool> matchFunc, IState targetState) :
        this(matchFunc, targetState, ((s, information) => information), "")
    {
    }

    public SimpleTransition(Func<string, IGameInformation, bool> matchFunc, IState targetState, string output) :
        this(matchFunc, targetState, ((s, information) => information), output)
    {
    }

    public SimpleTransition(
        Func<string, IGameInformation, bool> matchFunc,
        IState targetState,
        Func<string, IGameInformation, IGameInformation> executeFunc) :
        this(matchFunc, targetState, executeFunc, "")
    {
    }

    public SimpleTransition(
        Func<string, IGameInformation, bool> matchFunc,
        IState targetState,
        Func<string, IGameInformation, IGameInformation> executeFunc,
        string output)
    {
        MatchFunc = matchFunc;
        State = targetState;
        ExecuteFunc = executeFunc;
        Output = output;
    }

    public override bool Matches(string input, IGameInformation gameInformation)
    {
        return MatchFunc(input, gameInformation);
    }

    public override IState GetTargetState()
    {
        return State;
    }

    public override IGameInformation Execute(string input, IGameInformation gameInformation)
    {
        return ExecuteFunc(input, gameInformation);
    }

    public override string GetOutput()
    {
        return Output;
    }
}