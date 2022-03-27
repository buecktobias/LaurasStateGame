using Application.GameInformation;
using Application.StateFactory;
using Application.States;

namespace Application.Transitions;

public class SimpleTransitionBuilder<TGameInformation, TStateFactory>
    where TGameInformation : IGameInformation
    where TStateFactory : IStateFactory
{
    private TransitionExecuteFunc? _executeFunc;
    private TransitionMatchFunc? _matchFunc;

    private TransitionMatchFunc MatchFunc
    {
        get { return _matchFunc ?? ((_, _) => true); }
        set => _matchFunc = value;
    }

    private TransitionExecuteFunc ExecuteFunc
    {
        get => _executeFunc ?? ((_, information) => information);
        set => _executeFunc = value;
    }

    private IState<TGameInformation> TargetState { get; set; }

    private string Output { get; set; }

    public void SetMatchFunc(TransitionMatchFunc? matchFunc)
    {
        MatchFunc = matchFunc;
    }

    public void SetExecuteFunc(TransitionExecuteFunc? executeFunc)
    {
        ExecuteFunc = executeFunc;
    }

    public void SetOutput(string newOutput)
    {
        Output = newOutput;
    }

    public void SetTargetState(IState<TGameInformation> state)
    {
        TargetState = state;
    }

    public ITransition<TGameInformation> GetTransition()
    {
        return new SimpleTransition<TGameInformation, TStateFactory>(Output, TargetState, ExecuteFunc, MatchFunc);
    }
}