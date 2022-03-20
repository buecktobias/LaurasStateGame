namespace Application;

public abstract class AbstractState : IState
{
    private ITransitionFactory _transitionFactory;
    private IList<ITransition> Transitions { get; set; }

    protected AbstractState()
    {
        _transitionFactory = new TransitionFactory();
        Transitions = new List<ITransition>();
    }

    public abstract string GetIntroOutput();

    public ITransition GetMatchingTransitionInput(string input)
    {
        var transitionOrNull = GetMatchedTransitions(input);
        return transitionOrNull ?? _transitionFactory.GetNoMatchTransition();
    }

    private ITransition? GetMatchedTransitions(string input)
    {
        return Transitions.FirstOrDefault(transition => transition.Matches(input));
    }
    public abstract string GetOutroOutput();
    public abstract bool IsEndState();
}