namespace Application.Transitions;

public class SimpleTransition : AbstractTransition
{
    private Func<string, IGameInformation, bool> MatchFunc { get; set; }
    private IState State { get; set; }
    public SimpleTransition(Func<string, IGameInformation, bool> matchFunc, IState targetState)
    {
        MatchFunc = matchFunc;
        State = targetState;
    }
    public override bool Matches(string input, IGameInformation gameInformation)
    {
        return MatchFunc(input, gameInformation);
    }

    public override IState GetTargetState()
    {
        return State;
    }
}