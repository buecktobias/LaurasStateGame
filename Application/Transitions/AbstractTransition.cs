namespace Application;

public abstract class AbstractTransition : ITransition
{
    public IStateFactory StateFactory { get; }

    protected AbstractTransition()
    {
        StateFactory = Application.StateFactory.GetInstance();
    }

    public abstract bool Matches(string input, IGameInformation gameInformation);

    public abstract IGameInformation Execute(string input, IGameInformation gameInformation);
    

    public abstract IState GetTargetState();
    public abstract string GetOutput();
}