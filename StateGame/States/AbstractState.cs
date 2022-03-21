using Application.GameInformation;
using Application.TransitionFactory;
using Application.Transitions;

namespace Application.States;

public abstract class AbstractState<TGameInformation, TTransitionFactory> : IState<TGameInformation> 
    where TGameInformation : IGameInformation
    where TTransitionFactory : ITransitionFactory <TGameInformation>
{
    protected readonly TTransitionFactory RockPaperScissorTransitionFactory;
    
    protected AbstractState(TTransitionFactory transitionFactory)
    {
        RockPaperScissorTransitionFactory = transitionFactory;
        Transitions = new List<ITransition<TGameInformation>>();
    }


    protected IList<ITransition<TGameInformation>> Transitions { get; }

    public virtual string GetIntroOutput()
    {
        return "";
    }

    public ITransition<TGameInformation> GetMatchingTransitionInput(string input, TGameInformation rockPaperScissorGameInformation)
    {
        var transitionOrNull = GetMatchedTransitions(input, rockPaperScissorGameInformation);
        return transitionOrNull ?? RockPaperScissorTransitionFactory.GetNoMatchTransition();
    }

    public virtual string GetOutroOutput()
    {
        return "";
    }

    public virtual bool IsEndState()
    {
        return false;
    }

    public virtual TGameInformation Execute(TGameInformation rockPaperScissorGameInformation)
    {
        return rockPaperScissorGameInformation;
    }

    public virtual void CreateTransitions()
    {
    }
    private ITransition<TGameInformation>? GetMatchedTransitions(string input, TGameInformation rockPaperScissorGameInformation)
    {
        return Transitions.FirstOrDefault(transition => transition.Matches(input, rockPaperScissorGameInformation));
    }


}