using Application.GameInformation;
using Application.TransitionFactory;
using Application.Transitions;

namespace Application.States;

public class SimpleStateBuilder <TGameInformation, TTransitionFactory>
where TGameInformation : IGameInformation
where TTransitionFactory : ITransitionFactory<TGameInformation>
{
    private readonly SimpleState<TGameInformation, TTransitionFactory> _state;

    protected SimpleStateBuilder(TTransitionFactory transitionFactory)
    {
        _state = new SimpleState<TGameInformation, TTransitionFactory>(transitionFactory);
    }

    public void SetAsEndState()
    {
        _state.EndState = true;
    }
    public void SetIntroOutput(string introOutput)
    {
        _state.IntroOutput = introOutput;
    }
    
    public void SetOutroOutput(string outroOutput)
    {
        _state.OutroOutput = outroOutput;
    }

    public void SetExecuteFunction(ExecutionFunction executionFunction)
    {
        _state.ExecuteFunc = executionFunction;
    }

    public void AddTransition(ITransition<TGameInformation> transition)
    {
        _state.NewTransitions.Add(transition);
    }

    public void SetTransitions(IList<ITransition<TGameInformation>> transitions)
    {
        _state.NewTransitions = transitions;
    }

    public IState<TGameInformation> GetState()
    {
        return _state;
    }

    public void SetNeedsInput(bool needsInput)
    {
        _state.NeedsInput = needsInput;
    }
    
    
}