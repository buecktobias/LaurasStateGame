namespace Application;

public abstract class AbstractState : IState
{
    protected ITransitionFactory _transitionFactory;
    protected IList<ITransition> Transitions { get; set; }

    protected AbstractState()
    {
        _transitionFactory = TransitionFactory.GetInstance();
        Transitions = new List<ITransition>();
        CreateTransitions();
    }

    public abstract void CreateTransitions();

    public abstract string GetIntroOutput();

    public ITransition GetMatchingTransitionInput(string input, IGameInformation gameInformation)
    {
        var transitionOrNull = GetMatchedTransitions(input, gameInformation);
        return transitionOrNull ?? _transitionFactory.GetNoMatchTransition();
    }

    private ITransition? GetMatchedTransitions(string input, IGameInformation gameInformation)
    {
        return Transitions.FirstOrDefault(transition => transition.Matches(input, gameInformation));
    }
    public abstract string GetOutroOutput();
    public abstract bool IsEndState();

    public abstract IGameInformation Execute(IGameInformation gameInformation);
}