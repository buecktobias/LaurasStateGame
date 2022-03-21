using Application.GameInformation;
using Application.StateFactory;
using Application.States;

namespace Application.Transitions;

public abstract class AbstractTransition<TGameInformation, TStateFactory> : ITransition<TGameInformation>
where TGameInformation : IGameInformation
where TStateFactory : IStateFactory
{
    protected AbstractTransition(TStateFactory stateFactory)
    {
        StateFactory = stateFactory;
    }
    protected  TStateFactory StateFactory { get; }

    public abstract bool Matches(string input, TGameInformation gameInformation);

    public virtual TGameInformation Execute(string input, TGameInformation gameInformation)
    {
        return gameInformation;
    }

    public abstract IState<TGameInformation> GetTargetState();

    public virtual string GetOutput()
    {
        return "";
    }
}