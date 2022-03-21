using Application.GameInformation;
using Application.StateFactory;
using Application.States;
using Application.TransitionFactory;

namespace Application.Transitions;

public class SimpleTransitionBuilder <TGameInformation, TStateFactory>
where TGameInformation : IGameInformation
where TStateFactory : IStateFactory
{
    private SimpleTransition<TGameInformation, TStateFactory> _transition;

    public SimpleTransitionBuilder(TStateFactory stateFactory)
    {
        _transition = new SimpleTransition<TGameInformation, TStateFactory>(stateFactory);
    }

    public void SetMatchFunc(TransitionMatchFunc matchFunc)
    {
        _transition.MatchFunc = matchFunc;
    }

    public void SetExecuteFunc(TransitionExecuteFunc executeFunc)
    {
        _transition.ExecuteFunc = executeFunc;
    }

    public void SetOutput(string newOutput)
    {
        _transition.Output = newOutput;
    }

    public void SetTargetState(IState<TGameInformation> state)
    {
        _transition.TargetState = state;
    }

    public ITransition<TGameInformation> GetTransition()
    {
        return _transition;
    }
}