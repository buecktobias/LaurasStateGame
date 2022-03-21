using Application.Exceptions;
using Application.GameInformation;
using Application.StateFactory;
using Application.States;

namespace Application.Transitions;

public delegate bool TransitionMatchFunc(string inputText, IGameInformation gameInformation);

public delegate IGameInformation TransitionExecuteFunc(string inputText, IGameInformation gameInformation);
public class SimpleTransition<TGameInformation, TStateFactory> : AbstractTransition<TGameInformation, TStateFactory>
where TGameInformation : IGameInformation
where TStateFactory : IStateFactory
{
    public TransitionMatchFunc MatchFunc { get; set; }
    public TransitionExecuteFunc ExecuteFunc { get; set; }
    public IState<TGameInformation>? TargetState { get; set; }
    public string Output { get; set; }

    
    public SimpleTransition(TStateFactory stateFactory) : base(stateFactory)
    {
        MatchFunc = (_, _) => true;
        ExecuteFunc = (_, information) => information;
        TargetState = null;
        Output = "";
    }


    public override bool Matches(string input, TGameInformation gameInformation)
    {
        return MatchFunc(input, gameInformation);
    }

    public override IState<TGameInformation> GetTargetState()
    {
        if (TargetState == null) throw new TargetStateNotSetException();
        return TargetState;
    }

    public override TGameInformation Execute(string input, TGameInformation rockPaperScissorGameInformation)
    {
        return (TGameInformation) ExecuteFunc(input, rockPaperScissorGameInformation);
    }

    public override string GetOutput()
    {
        return Output;
    }
}