namespace Application.Transitions;
using StateFactory;

public abstract class AbstractTransition : ITransition
{
    protected AbstractTransition()
    {
        RockPaperScissorStateFactory = Application.StateFactory.RockPaperScissorStateFactory.GetInstance();
    }
    protected IRockPaperScissorStateFactory RockPaperScissorStateFactory { get; }

    public abstract bool Matches(string input, IGameInformation gameInformation);

    public virtual IGameInformation Execute(string input, IGameInformation gameInformation)
    {
        return gameInformation;
    }

    public abstract IState GetTargetState();

    public virtual string GetOutput()
    {
        return "";
    }
}