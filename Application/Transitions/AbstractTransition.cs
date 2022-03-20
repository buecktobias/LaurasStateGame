namespace Application;

public abstract class AbstractTransition : ITransition
{
    public IStateFactory StateFactory { get; }

    protected AbstractTransition()
    {
        StateFactory = new StateFactory();
    }

    public abstract bool Matches(string input);
    public abstract IState GetTargetState();
}