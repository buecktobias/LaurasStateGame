namespace Application.Transitions;

public class SimpleTransition : AbstractTransition
{
    private Func<string, IGameInformation, bool> MatchFunc { get; set; }
    private Func<string, IGameInformation, IGameInformation> ExecuteFunc { get; set; }
    private IState State { get; set; }
    private string Output { get; set; }
    public SimpleTransition(Func<string, IGameInformation, bool> matchFunc, IState targetState):
        this(matchFunc, targetState, ((s, information) => information), "")
    {
    }
    public SimpleTransition(Func<string, IGameInformation, bool> matchFunc, IState targetState, string output):
        this(matchFunc, targetState, ((s, information) => information), output)
    {
    }
    public SimpleTransition(Func<string, IGameInformation, bool> matchFunc, IState targetState,Func<string, IGameInformation, IGameInformation> executeFunc ):
        this(matchFunc, targetState, executeFunc, "")
    {
    }
    
    public SimpleTransition(Func<string, IGameInformation, bool> matchFunc, IState targetState, Func<string, IGameInformation, IGameInformation> executeFunc, string output)
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
        return this.ExecuteFunc(input, gameInformation);
    }

    public override string GetOutput()
    {
        return this.Output;
    }
}